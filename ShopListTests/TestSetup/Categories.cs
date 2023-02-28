using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListTests.TestSetup
{
    public static class Categories
    {
        public static void AddCategories(this ShopListContext context)
        {
            context.Categories.AddRange(

                new Category
                {
                    CategoryName = "Tamir Malzemeleri",
                    Description = "Tamir için kullanılan malzemeler"
                },
                new Category
                {
                    CategoryName = "Mutfak Malzemeleri",
                    Description = "Mutfak için kullanılan malzemeler"
                }
            );
        }
    }
}
