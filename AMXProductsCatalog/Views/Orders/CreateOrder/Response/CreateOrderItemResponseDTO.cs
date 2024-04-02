using System.Runtime.Serialization;

namespace AMXProductsCatalog.Views.Orders.CreateOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;

    [DataContract]
    public class CreateOrderItemResponseDTO
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public BaseProduct Product { get; set; }

        [DataMember]
        public int Quantity { get; set; }


        public CreateOrderItemResponseDTO() { }

        public CreateOrderItemResponseDTO(long id, BaseProduct product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
