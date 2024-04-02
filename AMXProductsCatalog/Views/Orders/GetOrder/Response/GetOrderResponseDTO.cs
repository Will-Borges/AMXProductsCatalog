namespace AMXProductsCatalog.Views.Orders.GetOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Domains.Customers;
    using AMXProductsCatalog.Core.Domain.Domains.Orders;

    public class GetOrderResponseDTO
    {
        public long Id { get; set; }
        public Customer Customer { get; set; } // revisar
        public GetOrderItemResponseDTO[] Items { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }


        public GetOrderResponseDTO() { }

        public GetOrderResponseDTO(long id, Customer customer, GetOrderItemResponseDTO[] items, decimal totalPrice, OrderStatus status)
        {
            Id = id;
            Customer = customer;
            Items = items;
            TotalPrice = totalPrice;
            Status = status;
        }
    }
}
