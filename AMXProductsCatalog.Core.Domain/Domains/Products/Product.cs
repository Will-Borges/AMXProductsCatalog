namespace AMXProductsCatalog.Core.Domain.Domains.Products
{
    using AMXProductsCatalog.Core.Domain.Domains.Generics.UniqueIds;

    public abstract class Product : IEntity
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
    }
}
