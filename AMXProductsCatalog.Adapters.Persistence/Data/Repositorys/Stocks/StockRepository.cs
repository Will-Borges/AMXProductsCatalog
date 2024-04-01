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
                return stockItem; //maybe
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

        public async Task<bool> UpdateStock(StockItemEntity newStockItem)
        {
            //try
            //{
            //    var originalStock = await _context.Stocks.Include(s => s.StockItems)
            //        .FirstOrDefaultAsync(s => s.Id == 1);

            //    originalStock!.StockItems.Add(newStockItem);

            //    int affectedRows = await _context.SaveChangesAsync();
            //    return affectedRows > 0;
            //}
            //catch (Exception ex)
            //{
            //    throw new InvalidOperationException("Erro ao atualizar o estoque.", ex);
            //}
            return false;
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
