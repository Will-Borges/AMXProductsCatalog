namespace AMXProductsCatalog.Core.Domain.Abstractions.Repository
{
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public interface IStockRepository
    {
        Task<long> InsertStockItem<T>(StockItemEntity<T> stockItem);
    }
}
