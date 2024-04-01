namespace AMXProductsCatalog.Core.Domain.Domains.Stocks
{
    public class Stock
    {
        public long Id { get; }
        public ISet<StockItem> StockItems { get; } = new HashSet<StockItem>();


        public Stock(long id)
        {
            Id = id;
        }

        public void InsertStockItems(StockItem stockItem)
        {
            StockItems.Add(stockItem);
        }
    }
}
