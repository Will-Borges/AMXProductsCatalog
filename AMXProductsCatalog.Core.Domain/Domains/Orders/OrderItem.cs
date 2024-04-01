using AMXProductsCatalog.Core.Domain.Abstractions.Products;

namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{
    public class OrderItem
    {
        public long Id { get; }
        public BaseProduct Product { get; }
        public int Quantity { get; }
        public decimal Price { get; }
    }
}
