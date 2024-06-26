﻿namespace AMXProductsCatalog.Core.Domain.Abstractions.Repository
{
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public interface IStockRepository
    {
        Task<long> InsertStockItem(StockItemEntity stockItem);
        Task CreateStock(StockEntity stockEntity);
        Task<bool> UpdateQuantityStockItem(long id, int quantity);
        Task<StockEntity> GetStock();
        Task<StockItemEntity> GetItemStockById(long id);
    }
}
