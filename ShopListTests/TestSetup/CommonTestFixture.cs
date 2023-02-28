using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework;

namespace ShopListTests.TestSetup
{
    public class CommonTestFixture
    {
        public ShopListContext DbContext { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<ShopListContext>().UseInMemoryDatabase(databaseName: "ShopListTestDb").Options;

            DbContext = new ShopListContext(options);
            DbContext.Database.EnsureCreated();

            DbContext.AddProducts();
            DbContext.AddCategories();
            DbContext.SaveChanges();
        }

        public DbContext GetTextContext()
        {
            return DbContext;
        }

    }
}
