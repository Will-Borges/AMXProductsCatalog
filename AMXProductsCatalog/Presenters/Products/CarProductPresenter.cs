﻿namespace AMXProductsCatalog.Presenters.Products
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.CreateProduct.Request;
    using AMXProductsCatalog.Views.GetProduct.Response;
    using AutoMapper;

    public class CarProductPresenter : ICarProductPresenter
    {
        private readonly IMapper _mapper;
        private readonly ICarProductService _carProductService;


        public CarProductPresenter(IMapper mapper, ICarProductService carProductService)
        {
            _carProductService = carProductService;
            _mapper = mapper;
        }


        public async Task<long> CreateCarProduct(CreateCarProductRequestDTO carRequestDTO)
        {
            ValidPriceCar(carRequestDTO.Price);

            var car = _mapper.Map<CarProduct>(carRequestDTO);

            var carId = await _carProductService.CreateCarProduct(car);
            return carId;
        }
        
        public async Task<GetCarProductResponseDTO[]> GetAllCarProducts(int pageSize, int pageNumber)
        {
            var carProducts = await _carProductService.GetAllCarProducts(pageSize, pageNumber);

            var carsResponse = _mapper.Map<GetCarProductResponseDTO[]>(carProducts);
            return carsResponse;
        }

        public async Task<GetCarProductResponseDTO> GetCarProductById(int id)
        {
            var carProducts = await _carProductService.GetCarProductById(id);

            var carsResponse = _mapper.Map<GetCarProductResponseDTO>(carProducts);
            return carsResponse;
        }

        public async Task<bool> DeleteCarProductById(long id)
        {
            var deleteWithSucess = await _carProductService.DeleteCarProductById(id);
            return deleteWithSucess;
        }

        private void ValidPriceCar(decimal price)
        {
            if (price <= 0)
                throw new InvalidOperationException("Car price must be greater than zero.");
        }
    }
}