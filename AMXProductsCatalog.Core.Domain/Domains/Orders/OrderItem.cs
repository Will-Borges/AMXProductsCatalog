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
        public BaseProduct Product { get; set; }

        [DataMember]
        public int Quantity { get; }

        public OrderItem(long id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public OrderItem() { }

        public OrderItem(long id, BaseProduct product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        public void InsertBaseProduct(BaseProduct product)
        {
            Product = product;
        }
    }
}
