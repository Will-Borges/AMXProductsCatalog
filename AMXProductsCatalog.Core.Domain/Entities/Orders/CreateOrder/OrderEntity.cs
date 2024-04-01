namespace AMXProductsCatalog.Core.Domain.Entities.Orders.CreateOrder
{
    using AMXProductsCatalog.Core.Domain.Domains.Orders;

    public class OrderEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long[] ItemsId { get; set; } = Array.Empty<long>();
        public decimal TotalPrice { get; set; } = decimal.Zero;
        public OrderStatus Status { get; set; }
    }
}
