using AMXProductsCatalog.Core.Domain.Abstractions.Products;

namespace AMXProductsCatalog.Core.Domain.Domains.Products
{
    public class CarProduct : BaseProduct
    {
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public long Id { get; set; }
        public decimal Price { get; set; }

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
