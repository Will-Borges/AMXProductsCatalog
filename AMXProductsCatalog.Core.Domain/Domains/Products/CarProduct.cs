using AMXProductsCatalog.Core.Domain.Abstractions.Products;
using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Domains.Products
{
    [DataContract]
    public class CarProduct : BaseProduct
    {
        [DataMember]
        public string Brand { get; }

        [DataMember]
        public string Model { get; }

        [DataMember]
        public int Year { get; }

        public CarProduct() { }

        public CarProduct(string brand, string model, int year, decimal price)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
