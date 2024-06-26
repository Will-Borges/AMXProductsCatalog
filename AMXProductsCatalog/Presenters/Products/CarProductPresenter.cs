﻿using AutoMapper;

namespace AMXProductsCatalog.Presenters.Products
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Domains.Generics.Verification;
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Core.Domain.Domains.Products.UpdateCar;
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Products.CreateCar.Request;
    using AMXProductsCatalog.Views.Products.GetCar.Response;
    using AMXProductsCatalog.Views.Products.UpdateCar.Request;

    public class CarProductPresenter : ICarProductPresenter
    {
        private readonly IMapper _mapper;
        private readonly ICarProductService _carProductService;


        public CarProductPresenter(IMapper mapper, ICarProductService carProductService)
        {
            _carProductService = carProductService;
            _mapper = mapper;
        }


        public async Task<long> CreateCarProduct(CreateCarProductRequestDTO carRequestDto)
        {
            ValueCheckerPresenter.CheckFor(carRequestDto);

            ValidPriceCar(carRequestDto.Price);

            var car = _mapper.Map<CarProduct>(carRequestDto);

            var carId = await _carProductService.CreateCarProduct(car);
            return carId;
        }
        
        public async Task<GetCarProductResponseDTO[]> GetAllCarProducts(int pageSize, int pageNumber)
        {
            var carProducts = await _carProductService.GetAllCarProducts(pageSize, pageNumber);

            var carsResponse = _mapper.Map<GetCarProductResponseDTO[]>(carProducts);
            return carsResponse;
        }

        public async Task<GetCarProductResponseDTO> GetCarProductById(long id)
        {
            ValueCheckerPresenter.CheckFor(id);

            var carProducts = await _carProductService.GetCarProductById(id);

            var carsResponse = _mapper.Map<GetCarProductResponseDTO>(carProducts);
            return carsResponse;
        }

        public async Task<bool> DeleteCarProductById(long id)
        {
            ValueCheckerPresenter.CheckFor(id);

            var deleteWithSucess = await _carProductService.DeleteCarProductById(id);
            return deleteWithSucess;
        }

        public async Task<bool> UpdateCarProduct(UpdateCarProductRequestDTO carRequestDto)
        {
            ValueCheckerPresenter.CheckFor(carRequestDto);

            var carsRequest = _mapper.Map<UpdateCarProductRequest>(carRequestDto);

            var updateWithSucess = await _carProductService.UpdateCarProduct(carsRequest);
            return updateWithSucess;
        }

        private void ValidPriceCar(decimal price)
        {
            if (price <= 0)
                throw new InvalidOperationException("Car price must be greater than zero.");
        }
    }
}
