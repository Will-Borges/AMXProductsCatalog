namespace AMXProductsCatalog.Core.Domain.Domains.Stocks.GetStock
{
    public class GetStockResponse
    {
        public long Id { get; }
        public ISet<GetStockItemResponse> StockItems { get; } = new HashSet<GetStockItemResponse>();


        public GetStockResponse(long id)
        {
            Id = id;
        }

        public void InsertStockItems(GetStockItemResponse stockItem)
        {
            StockItems.Add(stockItem);
        }
    }
}
