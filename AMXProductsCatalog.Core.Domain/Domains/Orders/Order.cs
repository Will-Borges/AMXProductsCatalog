namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{
    using AMXProductsCatalog.Core.Domain.Domains.Customers;

    public class Order
    {
        public long Id { get; private set; }
        public Customer Customer { get; }
        public OrderItem[] Items { get; private set; } = new OrderItem[0];
        public decimal TotalPrice { get; private set; } = decimal.Zero;
        public OrderStatus Status { get; private set; }


        public Order(long id,
                     Customer customer,
                     decimal totalPrice,
                     OrderStatus status)
        {
            TotalPrice = totalPrice;
            Status = status;
            Id = id;
            Customer = customer;
        }

        public Order(Customer customer)
        {
            Customer = customer;
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
