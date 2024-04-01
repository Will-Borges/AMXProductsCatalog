namespace AMXProductsCatalog.Presenters.Interfaces
{
    using AMXProductsCatalog.Views.Stocks.GetStock.Response;

    public interface IStockPresenter
    {
        Task<GetStockDTO> GetStock();
    }
}
