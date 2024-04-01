using System.Runtime.Serialization;

namespace AMXProductsCatalog.Views.Orders.CreateOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;

    [DataContract]
    public class CreateOrderItemDTO
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public BaseProduct Product { get; set; }

        [DataMember]
        public int Quantity { get; set; }


        public CreateOrderItemDTO() { }

        public CreateOrderItemDTO(long id, BaseProduct product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
