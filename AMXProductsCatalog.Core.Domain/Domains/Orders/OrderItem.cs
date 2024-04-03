using AMXProductsCatalog.Core.Domain.Abstractions.Products;
using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Domains.Orders
{

    public class OrderItem
    {
        public long Id { get; }
        public BaseProduct Product { get; set; }
        public int Quantity { get; }


        public OrderItem(int quantity)
        {
            Quantity = quantity;
        }

        public OrderItem() { }

        public OrderItem(long id, BaseProduct product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        public OrderItem(long id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public void InsertBaseProduct(BaseProduct product)
        {
            Product = product;
        }
    }
}
