namespace AMXProductsCatalog.Core.Application.Services.Products
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Stocks;
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

            var stock = await CreateStock(stockEntity);
            return stock;
        }

        //public async Task<> GetItemStockById()
        //{

        //}

        private async Task<GetStockResponse> CreateStock(StockEntity stockEntity)
        {
            var stock = new GetStockResponse(stockEntity.Id);

            foreach (var stockItemEntity in stockEntity.StockItems)
            {
                var stockItem = new GetStockItemResponse(stockItemEntity.Id, stockItemEntity.Quantity, stockItemEntity.LastUpdated);

                var product = await _carProductRepository.GetCarById(stockItemEntity.ProductId);

                stockItem.InsertBaseProduct(product);
                stock.InsertStockItems(stockItem);
            }

            return stock;
        }
    }
}
