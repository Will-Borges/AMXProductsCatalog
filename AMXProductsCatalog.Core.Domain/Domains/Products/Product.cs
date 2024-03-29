namespace AMXProductsCatalog.Core.Domain.Domains.Products
{
    public abstract class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public Product() { }
    }
}
