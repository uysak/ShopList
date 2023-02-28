using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShoppingListItemManager : IShoppingListItemService
    {
        private readonly IShoppingListItemDal _shoppingListItemDal;
        private readonly IProductCategoryDal _productCategoryDal;
        private readonly IShoppingListItemCategoryMapDal _shoppingListItemCategoryMapDal;

        private readonly IMapper _mapper;

        public ShoppingListItemManager(IShoppingListItemDal shoppingListItemDal, IMapper mapper, IProductCategoryDal productCategoryDal, IShoppingListItemCategoryMapDal shoppingListItemCategoryMapDal)
        {
            _shoppingListItemDal = shoppingListItemDal;

            _mapper = mapper;
            _productCategoryDal = productCategoryDal;
            _shoppingListItemCategoryMapDal = shoppingListItemCategoryMapDal;
        }
        // crud

        public IResult Add(ShoppingListItemForAddDto shoppingListItemDto)
        {
            var shoppingListItem = _mapper.Map<ShoppingListItem>(shoppingListItemDto);

            var check = CheckItemExist(shoppingListItemDto.ProductId);

            if (check.Success)
            {
                shoppingListItem = _shoppingListItemDal.Get(s=>s.ProductId == shoppingListItem.ProductId);
                shoppingListItem.Quantity += shoppingListItemDto.Quantity;
                _shoppingListItemDal.Update(shoppingListItem);
                return new ErrorDataResult(Messages.ListItemAlreadyExist);
            }

            var itemCategories = _productCategoryDal.GetAll(s => s.ProductId == shoppingListItemDto.ProductId);

            _shoppingListItemDal.Add(shoppingListItem);

            foreach(var itemCategory in itemCategories)
            {
                _shoppingListItemCategoryMapDal.AddMap(shoppingListItemDto.ShoppingListId, shoppingListItem.Id, itemCategory.CategoryId);
            }

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _shoppingListItemDal.Delete(_shoppingListItemDal.Get(s => s.Id == id));
            return new SuccessResult();
        }

        public IResult Update(int id, ShoppingListItemForUpdateDTO shoppingListItemForUpdateDTO)
        {
            var updatedEntity = _shoppingListItemDal.Get(s => s.Id == id);

            updatedEntity.Quantity = shoppingListItemForUpdateDTO.Quantity == default ? updatedEntity.Quantity : shoppingListItemForUpdateDTO.Quantity;
            updatedEntity.Note = shoppingListItemForUpdateDTO.Note == default ? updatedEntity.Note : shoppingListItemForUpdateDTO.Note;

            _shoppingListItemDal.Update(updatedEntity);
            return new SuccessResult();
        }

        public IDataResult<List<ShoppingListItem>> GetAllByListId(int listId)
        {
            var result = _shoppingListItemDal.GetAll(s => s.ShoppingListId == listId);
            return new SuccessDataResult<List<ShoppingListItem>>(result);
        }


        public IDataResult<List<ShoppingListItem>> GetAll()
        {
            var result = _shoppingListItemDal.GetAll();
            return new SuccessDataResult<List<ShoppingListItem>>(result);
        }

        public IResult CheckItemExist(int productId)
        {
            var result = _shoppingListItemDal.Get(s => s.ProductId == productId);
            if(result != null)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorDataResult();
            }


        }

    }
}
