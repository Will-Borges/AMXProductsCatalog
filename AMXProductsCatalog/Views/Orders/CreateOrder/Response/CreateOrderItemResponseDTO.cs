using System.Runtime.Serialization;

namespace AMXProductsCatalog.Views.Orders.CreateOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;

    [DataContract]
    public class CreateOrderItemResponseDTO
    {
        [DataMember]
        public BaseProduct Product { get; set; }

        [DataMember]
        public int Quantity { get; set; }


        public CreateOrderItemResponseDTO() { }

        public CreateOrderItemResponseDTO(BaseProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
