namespace AMXProductsCatalog.Core.Domain.Abstractions.Application.Services
{
    using AMXProductsCatalog.Core.Domain.Domains.Stocks.GetStock;

    public interface IStockService
    {
        Task<GetStockResponse> GetStock();
        Task<GetStockItemResponse> GetItemStockById(long id);
        Task<bool> UpdateQuantityStockItem(long id, int quantity);
    }
}
