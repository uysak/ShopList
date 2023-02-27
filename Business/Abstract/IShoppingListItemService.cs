using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShoppingListItemService
    {
        //crud 

        public IResult Add(ShoppingListItemForAddDto shoppingListItemDto);
        public IDataResult<List<ShoppingListItem>> GetAllByListId(int listId);

        public IDataResult<List<ShoppingListItem>> GetAll();


        public IResult Update(int id, ShoppingListItemForUpdateDTO shoppingListItemForUpdateDTO);

        public IResult Delete(int id);
    }
}
