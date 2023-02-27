using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Interceptors;
using Business.Utilities.Security.JWT;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();

            builder.RegisterType<StatusManager>().As<IStatusService>().SingleInstance();
            builder.RegisterType<EfStatusDal>().As<IStatusDal>().SingleInstance();

            builder.RegisterType<EfProductCategoryDal>().As<IProductCategoryDal>().SingleInstance();

            builder.RegisterType<ShoppingListManager>().As<IShoppingListService>().SingleInstance();
            builder.RegisterType<EfShoppingListDal>().As<IShoppingListDal>().SingleInstance();


            builder.RegisterType<ShoppingListItemManager>().As<IShoppingListItemService>().SingleInstance();
            builder.RegisterType<EfShoppingListItemDal>().As<IShoppingListItemDal>().SingleInstance();


            





            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
