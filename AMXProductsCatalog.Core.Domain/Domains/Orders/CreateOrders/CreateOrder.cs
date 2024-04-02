namespace AMXProductsCatalog.Core.Domain.Domains.Orders.CreateOrders
{
    public class CreateOrder
    {
        public long ItemId { get; }
        public int Quantity { get; }

        public CreateOrder(long itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }

        public CreateOrder()
        {
            
        }
    }
}
