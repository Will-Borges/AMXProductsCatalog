namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{
    using AMXProductsCatalog.Core.Domain.Domains.Customers;
    using System.Runtime.Serialization;

    public class Order
    {
        public long Id { get; private set; }
        public Customer Customer { get; }
        public OrderItem[] Items { get; }
        public decimal TotalPrice { get; private set; } = decimal.Zero;
        public OrderStatus Status { get; private set; }


        public Order(long id, Customer customer, OrderItem[] items)
        {
            Id = id;
            Customer = customer;
            Items = items;
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
    }
}
