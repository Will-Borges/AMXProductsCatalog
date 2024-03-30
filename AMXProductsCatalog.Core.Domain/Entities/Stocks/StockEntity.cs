using AMXProductsCatalog.Core.Domain.Domains.Products;

namespace AMXProductsCatalog.Core.Domain.Entities.Stocks
{
    public class StockEntity
    {
        public long Id { get; set; }
        public ISet<StockItemEntity<Product>> StockItems { get; set; }


        public StockEntity() { }

        public StockEntity(long id)
        {
            Id = id;
        }
    }
}
