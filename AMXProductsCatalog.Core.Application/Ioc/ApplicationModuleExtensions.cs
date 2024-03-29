using AMXProductsCatalog.Core.Application.Services;
using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AMXProductsCatalog.Core.Application.Ioc
{
    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICarProductService, CarProductService>();

            return services;
        }
    }
}
