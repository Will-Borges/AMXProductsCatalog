namespace AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Stocks
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Generics.Ramdom;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public class StockRepository : IStockRepository
    {
        public StockRepository() { }


        public async Task<long> InsertStockItem(StockItemEntity stockItem)
        {
            try
            {
                var stock = AMXDatabase.Stocks.FirstOrDefault(q => q.Id == 1);

                var stockItemObject = CreateStockItemEntity(stockItem);
                stock!.StockItems.Add(stockItemObject);

                return stockItem.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StockItemEntity> GetItemStockById(long id)
        {
            try
            {
                var stock = AMXDatabase.Stocks.FirstOrDefault(q => q.Id == 1);

                if (stock == null)
                {
                    return new StockItemEntity();
                }

                var stockItem = stock.StockItems.FirstOrDefault(q => q.Id == id);

                if (stockItem == null)
                {
                    return new StockItemEntity();
                }

                return stockItem; 
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when searching query.");
            }
        }

        public async Task CreateStock(StockEntity stockEntity)
        {
            try
            {
                var contextStockEntity = AMXDatabase.Stocks.FirstOrDefault();

                if (VerifyIfStockEntityExist(contextStockEntity))
                {
                    AMXDatabase.Stocks.Add(stockEntity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StockEntity> GetStock()
        {
            try
            {
                var stockEntity = AMXDatabase.Stocks.FirstOrDefault();

                if (stockEntity == null)
                {
                    return new StockEntity();
                }

                return stockEntity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateQuantityStockItem(long id, int quantity)
        {
            try
            {
                var stock = AMXDatabase.Stocks.FirstOrDefault(q => q.Id == 1);


                if (stock != null)
                {
                    var stockItem = stock.StockItems.FirstOrDefault(q => q.Id == id);
                    stockItem.Quantity = quantity;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when updating query.");
            }
        }

        private static bool VerifyIfStockEntityExist(StockEntity? stockEntity)
        {
            return stockEntity == null;
        }

        private StockItemEntity CreateStockItemEntity(StockItemEntity stockItem)
        {
            var stockItemObject = new StockItemEntity(
                    stockItem.ProductId,
                    stockItem.Quantity,
                    stockItem.LastUpdated);

            stockItemObject.Id = RandomIdGenerator.GenerateId(); ;

            return stockItemObject;
        }
    }
}
