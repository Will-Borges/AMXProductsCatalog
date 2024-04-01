using Microsoft.Extensions.DependencyInjection;

namespace AMXProductsCatalog.Core.Application.Ioc
{
    using AMXProductsCatalog.Core.Application.Services.Products;
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;

    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICarProductService, CarProductService>();
            services.AddScoped<IStockService, StockService>();
            
            return services;
        }
    }
}
