using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace DataAccess.Concrete.EntityFramework
{
    public class ShopListContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=shoplist;UID=root;PWD=123+abc+;Charset=utf8;SslMode=none";
                optionsBuilder.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion);
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }



        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

    }
}
