namespace AMXProductsCatalog.Core.Domain.Domains.Products.UpdateCar
{
    public class UpdateCarProductRequest
    {
        public long Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public decimal Price { get; }


        public UpdateCarProductRequest() { }

        public UpdateCarProductRequest(long id, string brand, string model, int year, decimal price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
