using AMXProductsCatalog.Core.Domain.Abstractions.Products;
using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Domains.Products
{

    public class CarProduct : BaseProduct
    {
        public string Brand { get; }
        public string Model { get; }
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
