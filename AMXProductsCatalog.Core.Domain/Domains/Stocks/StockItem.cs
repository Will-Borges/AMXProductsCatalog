namespace AMXProductsCatalog.Core.Domain.Domains.Stocks
{
    public class StockItem<TProduct>
    {
        public long Id { get; }
        public TProduct Product { get; }
        public int Quantity { get; }
        public DateTimeOffset LastUpdated { get; }
    }
}
