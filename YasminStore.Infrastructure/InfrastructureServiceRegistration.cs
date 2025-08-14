using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using YasminStore.ApplicationContract.Interfaces;
using YasminStore.Infrastructure.Repositories;

namespace YasminStore.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // تسجيل الـ Repositories (تنفيذ العقود)
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
