using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Entities.Products
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;

    public class CarProductEntity : BaseProduct
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }


        public CarProductEntity() { }

        public CarProductEntity(long id, string brand, string model, int year, decimal price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
