namespace AMXProductsCatalog.Core.Domain.Domains.Stocks
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;

    public class StockItem
    {
        public long Id { get; }
        public BaseProduct Product { get; private set; } 
        public int Quantity { get; }
        public DateTimeOffset LastUpdated { get; }

        public StockItem() { }

        public StockItem(long id, BaseProduct product, int quantity, DateTimeOffset lastUpdated)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            LastUpdated = lastUpdated;
        }

        public StockItem(long id, int quantity, DateTimeOffset lastUpdated)
        {
            Id = id;
            Quantity = quantity;
            LastUpdated = lastUpdated;
        }

        public void InsertBaseProduct(BaseProduct product)
        {
            Product = product;
        }
    }
}
