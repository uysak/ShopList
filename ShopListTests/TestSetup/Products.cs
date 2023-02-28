using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListTests.TestSetup
{
    public static class Products
    {
        public static void AddProducts(this ShopListContext context)
        {
            context.Products.AddRange(
                new Product
                {
                    ProductName = "Limon",
                    Description = "Taze Limon"
                },
                new Product
                {
                    ProductName = "Domates",
                    Description = "Organik Domates"
                },
                new Product
                {
                    ProductName = "Tornavida",
                    Description = "Yıldız Uçlu"
                }
            );
        }
    }
}
