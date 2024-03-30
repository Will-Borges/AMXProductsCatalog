using AutoMapper;

namespace AMXProductsCatalog.Core.Application.Services
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Core.Domain.Domains.Products.GetProduct;
    using AMXProductsCatalog.Core.Domain.Domains.Products.UpdateCar;
    using AMXProductsCatalog.Core.Domain.Entities.Products;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public class CarProductService : ICarProductService
    {
        private readonly IMapper _mapper;
        private readonly ICarProductRepository _carProductRepository;
        private readonly IStockRepository _stockRepository;


        public CarProductService(
            IMapper mapper,
            ICarProductRepository carProductRepository,
            IStockRepository stockRepository)
        {
            _mapper = mapper;
            _carProductRepository = carProductRepository;
            _stockRepository = stockRepository;
        }

        public async Task<long> CreateCarProduct(CarProduct carProduct)
        {
            var carEntity = _mapper.Map<CarProductEntity>(carProduct);

            var carId = await _carProductRepository.InsertCarProduct(carEntity);
            await InsertStockItem(carEntity);

            return carId;
        }

        public async Task<GetCarProductResponse[]> GetAllCarProducts(int pageSize, int pageNumber)
        {
            CarProductEntity[] carProducts = await _carProductRepository.GetAllCars(pageSize, pageNumber);

            var carsResponse = _mapper.Map<GetCarProductResponse[]>(carProducts);
            return carsResponse;
        }
        
        public async Task<GetCarProductResponse> GetCarProductById(int id)
        {
            var car = await _carProductRepository.GetCarById(id);

            var carResponse = _mapper.Map<GetCarProductResponse>(car);
            return carResponse;
        }

        public async Task<bool> DeleteCarProductById(long id)
        {
            var deleteWithSucess = await _carProductRepository.DeleteCarById(id);
            return deleteWithSucess;
        }

        public async Task<bool> UpdateCarProduct(UpdateCarProductRequest carRequest)
        {
            var carEntity = _mapper.Map<CarProductEntity>(carRequest);

            var deleteWithSucess = await _carProductRepository.UpdateCar(carEntity);
            return deleteWithSucess;
        }

        private async Task InsertStockItem(CarProductEntity carEntity)
        {
            var carStockItem = new StockItemEntity<CarProductEntity>(carEntity, DateTimeOffset.Now);
            await _stockRepository.InsertStockItem(carStockItem);
        }
    }
}
