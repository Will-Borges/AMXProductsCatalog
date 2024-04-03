namespace AMXProductsCatalog.Views.Orders.GetOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Domains.Orders;

    public class GetOrderResponseDTO
    {
        public long Id { get; set; }
        public GetOrderItemResponseDTO[] Items { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }


        public GetOrderResponseDTO() { }

        public GetOrderResponseDTO(long id, GetOrderItemResponseDTO[] items, decimal totalPrice, OrderStatus status)
        {
            Id = id;
            Items = items;
            TotalPrice = totalPrice;
            Status = status;
        }
    }
}
