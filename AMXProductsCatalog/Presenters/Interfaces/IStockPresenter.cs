namespace AMXProductsCatalog.Presenters.Interfaces
{
    using AMXProductsCatalog.Views.Stocks.GetStock.Response;

    public interface IStockPresenter
    {
        Task<GetStockResponseDTO> GetStock();
        Task<GetStockItemResponseDTO> GetItemStockById(long id);
        Task<bool> UpdateQuantityStockItem(long id, int quantity);
    }
}
