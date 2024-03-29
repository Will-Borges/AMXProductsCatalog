namespace AMXProductsCatalog.Core.Domain.Domains.Products
{
    public class CarProduct
    {
        public long Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public decimal Price { get; }


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
