namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{
    public class Order
    {
        public long Id { get; private set; }
        public OrderItem[] Items { get; private set; } = new OrderItem[0];
        public decimal TotalPrice { get; private set; } = decimal.Zero;
        public OrderStatus Status { get; private set; }


        public Order() { }

        public Order(long id,
                     decimal totalPrice,
                     OrderStatus status)
        {
            TotalPrice = totalPrice;
            Status = status;
            Id = id;
        }

        public void SetStatus(OrderStatus status)
        {
            Status = status;
        }

        public void SetTotalPrice()
        {
            foreach (var item in Items)
            {
                TotalPrice += (item.Quantity * item.Product.Price);
            }
        }

        public void SetId(long id)
        {
            Id += id;
        }

        public void SetItems(OrderItem[] items)
        {
            Items = items;
        }
    }
}
