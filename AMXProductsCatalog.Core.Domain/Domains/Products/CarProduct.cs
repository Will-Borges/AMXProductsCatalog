using AMXProductsCatalog.Core.Domain.Domains.Generics.UniqueIds;

namespace AMXProductsCatalog.Core.Domain.Domains.Products
{
    public class CarProduct : Product
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
