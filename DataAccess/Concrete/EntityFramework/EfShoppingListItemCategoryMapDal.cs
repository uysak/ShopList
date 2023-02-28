using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfShoppingListItemCategoryMapDal : IShoppingListItemCategoryMapDal
    {
        public void AddMap(int shoppingListId, int shoppingListItemId, int categoryId)
        {
            
            using(var context = new ShopListContext())
            {
                context.ShoppingListItemCategoryMaps.Add(
                    new ShoppingListItemCategoryMap
                    {
                        CategoryId = categoryId,
                        ShoppingListId = shoppingListId,
                        ShoppingListItemId = shoppingListItemId
                    });


                context.SaveChanges();
                    
            }
        }
    }
}
