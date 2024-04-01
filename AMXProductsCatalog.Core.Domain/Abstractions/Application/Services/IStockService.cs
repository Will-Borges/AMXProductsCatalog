namespace AMXProductsCatalog.Core.Domain.Abstractions.Application.Services
{
    using AMXProductsCatalog.Core.Domain.Domains.Stocks;

    public interface IStockService
    {
        Task<Stock> GetStock();
    }
}
