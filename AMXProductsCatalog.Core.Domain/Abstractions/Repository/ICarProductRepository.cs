using AMXProductsCatalog.Core.Domain.Entities.Products;

namespace AMXProductsCatalog.Core.Domain.Abstractions.Repository
{
    public interface ICarProductRepository
    {
        Task<long> InsertCarProduct(CarProductEntity car);
        Task<CarProductEntity[]> GetAllCars(int pageSize, int pageNumber);
        Task<CarProductEntity> GetCarById(long id);
        Task<bool> DeleteCarById(long id);
        Task<bool> UpdateCar(CarProductEntity updatedCar);
    }
}