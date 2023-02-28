using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IShoppingListItemCategoryMapDal
    {
        public void AddMap(int shoppingListId, int shoppingListItemId, int categoryId);
    }
}
