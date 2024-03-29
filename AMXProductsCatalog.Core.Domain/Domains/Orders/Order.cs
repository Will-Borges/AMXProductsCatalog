namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{
    using AMXProductsCatalog.Core.Domain.Domains.Customers;

    public class Order
    {
        public long Id { get; }
        public Customer Customer { get; }
        public OrderItem[] Items { get; }
        public decimal TotalPrice { get; }
        public OrderStatus Status { get; }
    }
}
