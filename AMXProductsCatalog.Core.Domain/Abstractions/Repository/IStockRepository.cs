namespace AMXProductsCatalog.Core.Domain.Abstractions.Repository
{
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public interface IStockRepository
    {
        Task<long> InsertStockItem(StockItemEntity<Product> stockItem);
    }
}
