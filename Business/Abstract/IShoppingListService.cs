using Business.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShoppingListService
    {
        //crud

        public IResult Add(ShoppingList shoppingList);
        //public IDataResult<List<ShoppingList>> GetAllItem(int listId);
        public IDataResult<List<ShoppingList>> GetAll();
        public IDataResult<List<ShoppingList>> GetAllListItemByCategoryId(int categoryId, int listId);

        public IDataResult<List<ShoppingListItem>> GetItemByCategoryId(int categoryId, int listId);

        public IResult Delete(int id);

        public IResult CheckListExist(int id);

    }
}
