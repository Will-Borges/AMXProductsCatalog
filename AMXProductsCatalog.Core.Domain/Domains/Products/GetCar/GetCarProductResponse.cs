namespace AMXProductsCatalog.Core.Domain.Domains.Products.GetProduct
{
    public class GetCarProductResponse
    {
        public long Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public decimal Price { get; }


        public GetCarProductResponse() { }

        public GetCarProductResponse(long id, string brand, string model, int year, decimal price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
