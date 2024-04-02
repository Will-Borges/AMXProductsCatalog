namespace AMXProductsCatalog.Core.Domain.Entities.Orders.CreateOrder
{
    public class OrderItemEntity
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public int Quantity { get; set; }

        public OrderItemEntity()
        {
            
        }

        public OrderItemEntity(long id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}
