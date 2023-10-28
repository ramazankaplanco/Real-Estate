using Tumsas.RealEstate.Business.Abstract;
using Tumsas.RealEstate.Business.Concrete;
using Tumsas.RealEstate.DataAccess;
using Tumsas.RealEstate.DataAccess.Abstract;
using Tumsas.RealEstate.DataAccess.Repository;

namespace Tumsas.RealEstate.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///
        /// <code>Scoped</code> Aynı anda iki istekte bulunursa (IUserService) tek bir UserService oluşturulur.
        /// <code>Transient</code> Aynı anda iki istekte bulunursa (IUserService) iki tane UserService oluşturulur.
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddCollection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}