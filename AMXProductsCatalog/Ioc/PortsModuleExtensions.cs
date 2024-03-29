namespace AMXProductsCatalog.Ioc
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Presenters.Products;

    public static class PortsModuleExtensions
    {
        public static IServiceCollection AddPortsPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICarProductPresenter, CarProductPresenter>();

            return services;
        }
    }
}
