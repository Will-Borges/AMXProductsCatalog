namespace AMXProductsCatalog.Core.Domain.Domains.Stocks
{
    public class Stock
    {
        public long Id { get; }
        public ISet<StockItem<object>> StockItems { get; } = new HashSet<StockItem<object>>();
    }
}
