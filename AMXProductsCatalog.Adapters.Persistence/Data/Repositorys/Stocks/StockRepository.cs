namespace AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Stocks
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public class StockRepository : IStockRepository
    {
        public async Task<long> InsertStockItem<TProduct>(StockItemEntity<TProduct> stockItem)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    await context.Database.EnsureCreatedAsync();

                    stockItem.Id = GenerateUniqueId(context);

                    var stockEntity = GetStockSet(context);

                    var stockItemObject = CreateStockItemEntity(stockItem);

                    stockEntity.StockItems.Add(stockItemObject);

                    await context.SaveChangesAsync();
                    return stockItem.Id;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error inserting stock item.", ex);
                }
            }
        }

        private static StockItemEntity<object> CreateStockItemEntity<TProduct>(StockItemEntity<TProduct> stockItem)
        {
            var stockItemObject = new StockItemEntity<object>(
                    stockItem.Id,
                    stockItem.Product,
                    stockItem.Quantity,
                    stockItem.LastUpdated);

            return stockItemObject;
        }

        private static StockEntity GetStockSet(AMXDbContext context)
        {
            var stockSet = context.Set<StockEntity>();

            var stockEntity = stockSet.FirstOrDefault();

            if (VerifyIfStockEntityExist(stockEntity))
            {
                stockEntity = new StockEntity();
                stockSet.Add(stockEntity);
            }

            return stockEntity;
        }

        private static bool VerifyIfStockEntityExist(StockEntity? stockEntity)
        {
            return stockEntity == null;
        }

        private long GenerateUniqueId(AMXDbContext context) //Criar generico
        {
            if (!context.Stocks.Any())
            {
                return 1;
            }

            long id = context.Cars.Max(q => q.Id) + 1;
            return id;
        }

        /*
         public async Task<long> InsertStockItem<TProduct>(StockItemEntity<TProduct> stockItem)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    await context.Database.EnsureCreatedAsync();

                    stockItem.Id = GenerateUniqueId(context);

                    //var stockSet = context.Set<StockEntity>();

                    //var stockEntity = stockSet.FirstOrDefault();

                    //// Verifique se o StockEntity existe
                    //if (stockEntity == null)
                    //{
                    //    stockEntity = new StockEntity();
                    //    stockSet.Add(stockEntity);
                    //}

                    // Adicione o StockItem à coleção StockItems do StockEntity
                    var stockItemObject = new StockItemEntity<object>
                    {
                        Id = stockItem.Id,
                        Product = stockItem.Product,
                        Quantity = stockItem.Quantity,
                        LastUpdated = stockItem.LastUpdated
                    };
                    stockEntity.StockItems.Add(stockItemObject);

                    await context.SaveChangesAsync();
                    return stockItem.Id;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error inserting stock item.", ex);
                }
            }
        }
         */
    }
}
