using System.Data.Entity;

namespace AMXProductsCatalog.Core.Domain.Domains.Stocks
{
    using AMXProductsCatalog.Core.Domain.Domains.Generics.UniqueIds;
    using AMXProductsCatalog.Core.Domain.Domains.Products;

    public class Stock
    {
        public long Id { get; private set; }
        public ISet<StockItem<Product>> StockItems { get; }


        public void InsertStockItems(StockItem<Product> stockItem)
        {
            StockItems.Add(stockItem);
        }

        public void InsertNewId(DbSet<CarProduct> cars)
        {
            var id = GenerationUniqueId.GenerateUniqueId(cars);
            Id = id;
        }
    }
}
