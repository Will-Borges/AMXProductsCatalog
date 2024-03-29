namespace AMXProductsCatalog.Core.Domain.Entities.Stocks
{
    public class StockEntity
    {
        public long Id { get; set; }
        public ISet<StockItemEntity<object>> StockItems { get; set; } = new HashSet<StockItemEntity<object>>();
    }
}
