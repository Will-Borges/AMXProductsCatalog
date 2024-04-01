using System.Runtime.Serialization;

namespace AMXProductsCatalog.Views.Orders.CreateOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Domains.Customers;
    using AMXProductsCatalog.Core.Domain.Domains.Orders;

    [DataContract]
    public class CreateOrderResponseDTO
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public Customer Customer { get; set; } // revisar

        [DataMember]
        public CreateOrderItemDTO[] Items { get; set; }

        [DataMember]
        public decimal TotalPrice { get; set; }

        [DataMember]
        public OrderStatus Status { get; set; }


        public CreateOrderResponseDTO() { }

        public CreateOrderResponseDTO(long id, Customer customer, CreateOrderItemDTO[] items, decimal totalPrice, OrderStatus status)
        {
            Id = id;
            Customer = customer;
            Items = items;
            TotalPrice = totalPrice;
            Status = status;
        }
    }
}
