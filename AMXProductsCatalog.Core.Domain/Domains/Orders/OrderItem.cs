using AMXProductsCatalog.Core.Domain.Abstractions.Products;
using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public long Id { get; }

        [DataMember]
        public BaseProduct Product { get; }

        [DataMember]
        public int Quantity { get; }


        public OrderItem() { }

        public OrderItem(long id, BaseProduct product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
