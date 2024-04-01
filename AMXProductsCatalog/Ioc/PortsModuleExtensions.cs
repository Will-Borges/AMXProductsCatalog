namespace AMXProductsCatalog.Ioc
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Presenters.Products;
    using AMXProductsCatalog.Presenters.Stocks;

    public static class PortsModuleExtensions
    {
        public static IServiceCollection AddPortsPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICarProductPresenter, CarProductPresenter>();
            services.AddScoped<IStockPresenter, StockPresenter>();

            return services;
        }
    }
}
