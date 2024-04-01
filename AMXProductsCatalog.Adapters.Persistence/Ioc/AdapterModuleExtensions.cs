using Microsoft.Extensions.DependencyInjection;

namespace AMXProductsCatalog.Adapters.Persistence.Ioc
{
    using AMXProductsCatalog.Adapters.Persistence.Data;
    using AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Products;
    using AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Stocks;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;

    public static class AdapterModuleExtensions
    {
        public static IServiceCollection AddPersistenceRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarProductRepository, CarProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            return services;
        }
    }
}
