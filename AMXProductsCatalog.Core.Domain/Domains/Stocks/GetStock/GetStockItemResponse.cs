using AMXProductsCatalog.Core.Domain.Abstractions.Products;

namespace AMXProductsCatalog.Core.Domain.Domains.Stocks.GetStock
{
    public class GetStockItemResponse
    {
        public long Id { get; }
        public BaseProduct Product { get; private set; }
        public int Quantity { get; }
        public DateTimeOffset LastUpdated { get; }


        public GetStockItemResponse(long id, int quantity, DateTimeOffset lastUpdated)
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
