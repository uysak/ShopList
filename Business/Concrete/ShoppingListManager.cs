using Business.Abstract;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShoppingListManager : IShoppingListService
    {
        private readonly IShoppingListDal _shoppingListDal;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IShoppingListItemService _shoppingListItemService;
        private readonly IProductCategoryDal _productCategoryDal;
        public ShoppingListManager(IShoppingListDal shoppingListDal,IProductCategoryDal productCategoryDal, IShoppingListItemService shoppingListItemService,IProductService productService,ICategoryService categoryService)
        {
            _shoppingListDal = shoppingListDal;
            _productService = productService;
            _categoryService = categoryService;
            _shoppingListItemService = shoppingListItemService;
            _productCategoryDal = productCategoryDal;
        }
        public IResult Add(ShoppingList shoppingList)
        {
            _shoppingListDal.Add(shoppingList);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _shoppingListDal.Delete(_shoppingListDal.Get(s => s.Id == id));
            return new SuccessResult();
        }

        public IDataResult<ShoppingList> GetListById(int id)
        {
            var result = _shoppingListDal.Get(s => s.Id == id);
            if(result == null)
            {
                return new ErrorDataResult<ShoppingList>();
            }

            return new SuccessDataResult<ShoppingList>(result);
        }

        public IDataResult<List<ShoppingList>> GetAll()
        {
            var result = _shoppingListDal.GetAll();
            return new SuccessDataResult<List<ShoppingList>>(result);
        }

        public IDataResult<List<ShoppingList>> GetAllListItemByCategoryId(int categoryId) //kategori bazlı liste filtrelemesi
        {
            var productsByCategory = from pc in _productCategoryDal.GetAll()
                                     join p in _productService.GetAll().Data on pc.ProductId equals p.Id
                                     join c in _categoryService.GetAll().Data on pc.CategoryId equals c.Id
                                     where c.Id == categoryId

                                     select new { ProductId = p.Id, CategoryName = c.CategoryName };

            var shoppingListsWithProducts = from sl in GetAll().Data
                                            join sli in _shoppingListItemService.GetAll().Data on sl.Id equals sli.ShoppingListId
                                            join pc in productsByCategory on sli.ProductId equals pc.ProductId
                                            select sl;

            return new SuccessDataResult<List<ShoppingList>>(shoppingListsWithProducts.Distinct().ToList());
        }


        public IDataResult<List<ShoppingListItem>> GetItemByCategoryId(int categoryId, int listId)
        {
            var productCategories = _productCategoryDal.GetAll(s => s.CategoryId == categoryId); 

            var productIds = productCategories.Select(s => s.ProductId).ToList();

            var listItems = _shoppingListItemService.GetAllByListId(listId);

            var shoppingListItems = listItems.Data.Where(s => productIds.Contains(s.ProductId)).ToList();

            return new SuccessDataResult<List<ShoppingListItem>>(shoppingListItems);

        }


        public IResult CheckListExist(int id)
        {
            var result = _shoppingListDal.Get(s => s.Id == id);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

    }
}
