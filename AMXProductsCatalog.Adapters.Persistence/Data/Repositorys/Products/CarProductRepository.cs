using Microsoft.EntityFrameworkCore;

namespace AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Products
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Generics.Ramdom;
    using AMXProductsCatalog.Core.Domain.Domains.Paginates;
    using AMXProductsCatalog.Core.Domain.Entities.Products;

    public class CarProductRepository : ICarProductRepository
    {
        public CarProductRepository()
        {
        }

        public async Task<long> InsertCarProduct(CarProductEntity car)
        {
            try
            {
                car.Id = RandomIdGenerator.GenerateId();
                AMXDatabase.Cars.Add(car);

                return car.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inserting car.");
            }

        }

        public async Task<CarProductEntity[]> GetAllCars(int pageSize, int pageNumber)
        {
            try
            {
                //IOrderedQueryable
                //var query = (IOrderedQueryable<CarProductEntity>)AMXDatabase.Cars.OrderBy(c => c.Id);
                IQueryable<CarProductEntity> query = AMXDatabase.Cars.AsQueryable().OrderBy(c => c.Id);
                
                if (pageSize <= 0 || pageNumber <= 0)
                {
                    return query.ToArray();
                }

                var pagedQuery = Pagination.GetPage(pageSize, pageNumber, query);
                return pagedQuery.ToArray();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when searching all cars.");
            }
        }

        public async Task<CarProductEntity> GetCarById(long id)
        {
            try
            {
                var car = AMXDatabase.Cars.FirstOrDefault(q => q.Id == id);

                if (car == null)
                {
                    return new CarProductEntity();
                }

                return car;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when searching query.");
            }
        }

        public async Task<bool> UpdateCar(CarProductEntity updatedCar)
        {
            try
            {
                var car = AMXDatabase.Cars.FirstOrDefault(q => q.Id == updatedCar.Id);

                if (car != null)
                {
                   // car.ProductId = updatedCar.ProductId;
                    car.Brand = updatedCar.Brand;
                    car.Model = updatedCar.Model;
                    car.Year = updatedCar.Year;
                    car.Price = updatedCar.Price;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when updating query.");
            }
        }

        public async Task<bool> DeleteCarById(long id)
        {
            try
            {
                int car = AMXDatabase.Cars.RemoveAll(q => q.Id == id);

                return car > 0;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when deleting car");
            }

        }
    }
}
