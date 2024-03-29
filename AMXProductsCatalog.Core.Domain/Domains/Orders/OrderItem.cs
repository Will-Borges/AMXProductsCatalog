using AMXProductsCatalog.Core.Domain.Domains.Products;

namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{
    public class OrderItem
    {
        public long Id { get; }
        public Product Product { get; }
        public int Quantity { get; }
        public decimal Price { get; }
    }
}
