using AutoMapper;

namespace AMXProductsCatalog.Core.Application.Services
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Core.Domain.Domains.Products.GetProduct;
    using AMXProductsCatalog.Core.Domain.Entities.Products;

    public class CarProductService : ICarProductService
    {
        private readonly IMapper _mapper;
        private readonly ICarProductRepository _carProductRepository;


        public CarProductService(IMapper mapper, ICarProductRepository carProductRepository)
        {
            _mapper = mapper;
            _carProductRepository = carProductRepository;
        }

        public async Task<long> CreateCarProduct(CarProduct carProduct)
        {
            var car = _mapper.Map<CarProductEntity>(carProduct);

            var carId = await _carProductRepository.InsertCarProduct(car);
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
    }
}
