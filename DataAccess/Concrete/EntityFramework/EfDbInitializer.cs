using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public static class EFDbInitializer
    {
        public static void EnsureCreated(ShopListContext _db)
        {
            _db.Database.EnsureCreated();
        }

        public static void Migrate(ShopListContext _db)
        {
            _db.Database.Migrate();
        }

        public static void Initialize(ShopListContext _db)
        {
            AddDefaultCategory(_db);
        }



        private static void AddDefaultCategory(ShopListContext _db)
        {
            if (_db.Categories.Any())
            {
                return;
            }

            _db.Categories.Add(new Category
            {
                CategoryName = "Mutfak Malzemeleri"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Sebze"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Meyve"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Kahvaltılıklar"
            });


            _db.Categories.Add(new Category
            {
                CategoryName = "Ev Malzemeleri"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Temizlik"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Elektronik"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Tamir Malzemeleri"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "El Aletleri"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Hırdavat"
            });

            _db.SaveChanges();
        }

        public static void AddDefaultProducts(ShopListContext _db)
        {

            if (_db.Products.Any())
                return;

            _db.Products.Add(new Product
            {
                ProductName = "Domates",
                Description = "Taze ve çürüksüz"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Limon",
                Description = "Taze ve çürüksüz"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Yumurta",
                Description = "Organik"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Süt",
                Description = "Laktozsuz"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Peynir",
                Description = "Tam Yağlı"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Çamaşır Deterjanı",
                Description = "Kaliteli"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Bulaşık Deterjanı",
                Description = "Hassas eller için özel üretilmiş"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Televizyon",
                Description = "Akıllı TV"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Ses Sistemi",
                Description = "Bluetooth özellikli"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Pense",
                Description = "Kaliteli marka"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Yankeski",
                Description = "Büyük boy"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Beton Çivisi",
                Description = "4 x 60 Ölçülerinde"
            });

            _db.Products.Add(new Product
            {
                ProductName = "Pul ve Somun",
                Description = "Metrik 7"
            });


        }

        public static void AddDefaultProductCategory(ShopListContext _db)
        {
            if (_db.ProductCategories.Any())
                return;


            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 1,
                CategoryId = 1
            });


            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 1,
                CategoryId = 2
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 2,
                CategoryId = 1
            });


            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 2,
                CategoryId = 2
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 3,
                CategoryId = 1
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 3,
                CategoryId = 4
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 4,
                CategoryId = 1
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 4,
                CategoryId = 4
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 5,
                CategoryId = 1
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 5,
                CategoryId = 4
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 6,
                CategoryId = 5
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 6,
                CategoryId = 6
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 7,
                CategoryId = 5
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 7,
                CategoryId = 6
            });


            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 8,
                CategoryId = 5
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 8,
                CategoryId = 7
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 9,
                CategoryId = 5
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 9,
                CategoryId = 7
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 10,
                CategoryId = 8
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 10,
                CategoryId = 9
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 11,
                CategoryId = 8
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 11,
                CategoryId = 9
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 12,
                CategoryId = 8
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 12,
                CategoryId = 10
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 13,
                CategoryId = 8
            });

            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 13,
                CategoryId = 10
            });


        }


    }
}
