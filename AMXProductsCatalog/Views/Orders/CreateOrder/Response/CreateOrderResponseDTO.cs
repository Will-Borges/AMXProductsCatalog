using System.Runtime.Serialization;

namespace AMXProductsCatalog.Views.Orders.CreateOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Domains.Orders;

    public class CreateOrderResponseDTO
    {
        public long Id { get; set; }
        public CreateOrderItemResponseDTO[] Items { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }


        public CreateOrderResponseDTO() { }

        public CreateOrderResponseDTO(long id, CreateOrderItemResponseDTO[] items, decimal totalPrice, OrderStatus status)
        {
            Id = id;
            Items = items;
            TotalPrice = totalPrice;
            Status = status;
        }
    }
}
