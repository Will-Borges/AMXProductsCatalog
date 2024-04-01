namespace AMXProductsCatalog.Core.Application.Services.Stocks
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Stocks.GetStock;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly ICarProductRepository _carProductRepository;


        public StockService(
            IStockRepository stockRepository,
            ICarProductRepository carProductRepository)
        {
            _stockRepository = stockRepository;
            _carProductRepository = carProductRepository;

        }


        public async Task<GetStockResponse> GetStock()
        {
            var stockEntity = await _stockRepository.GetStock();

            var stock = await CreateGetStockResponse(stockEntity);
            return stock;
        }

        public async Task<GetStockItemResponse> GetItemStockById(long id)
        {
            var itemEntity = await _stockRepository.GetItemStockById(id);

            var item = await CreateGetStockItemResponse(itemEntity);
            return item;
        }

        public async Task<bool> UpdateQuantityStockItem(long id, int quantity)
        {
            var updateWithSucess = await _stockRepository.UpdateQuantityStockItem(id, quantity);
            return updateWithSucess;
        }

        private async Task<GetStockResponse> CreateGetStockResponse(StockEntity stockEntity)
        {
            var stock = new GetStockResponse(stockEntity.Id);

            foreach (var stockItemEntity in stockEntity.StockItems)
            {
                var stockItem = await CreateGetStockItemResponse(stockItemEntity);
                stock.InsertStockItems(stockItem);
            }

            return stock;
        }

        private async Task<GetStockItemResponse> CreateGetStockItemResponse(StockItemEntity stockItemEntity)
        {
            var stockItem = new GetStockItemResponse(stockItemEntity.Id, stockItemEntity.Quantity, stockItemEntity.LastUpdated);

            var product = await _carProductRepository.GetCarById(stockItemEntity.ProductId);

            stockItem.InsertBaseProduct(product);
            return stockItem;
        }
    }
}
