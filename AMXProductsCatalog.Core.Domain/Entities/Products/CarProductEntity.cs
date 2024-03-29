namespace AMXProductsCatalog.Core.Domain.Entities.Products
{
    public class CarProductEntity
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }


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
