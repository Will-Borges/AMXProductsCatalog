namespace AMXProductsCatalog.Core.Domain.Domains.Orders.CreateOrders
{
    public class CreateOrder
    {
        public long ProductId { get; }
        public int Quantity { get; }

        public CreateOrder(long productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public CreateOrder()
        {
            
        }
    }
}
