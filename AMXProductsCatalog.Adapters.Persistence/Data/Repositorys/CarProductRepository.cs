﻿using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
using AMXProductsCatalog.Core.Domain.Domains.Paginates;
using AMXProductsCatalog.Core.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AMXProductsCatalog.Adapters.Persistence.Data.Repositorys
{
    public class CarProductRepository : ICarProductRepository
    {
        public async Task<long> InsertCarProduct(CarProductEntity car)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    await context.Database.EnsureCreatedAsync();

                    car.Id = GenerateUniqueId(context);

                    context.Cars.Add(car);

                    await context.SaveChangesAsync();
                    return car.Id;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error inserting car.");
                }
            }
        }

        public async Task<CarProductEntity[]> GetAllCars(int pageSize, int pageNumber)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    var cars = context.Cars.OrderBy(c => c.Id).ToArray();

                    if (pageSize <= 0 || pageNumber <= 0)
                    {
                        return cars;
                    }

                    var query = Pagination.GetPage(pageSize, pageNumber, cars);
                    return query;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error when searching all cars.");
                }
            }
        }

        //----------

        public async Task<CarProductEntity> GetCarById(long id)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    return await context.Cars.FindAsync(id);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error when searching cars.");
                }
            }
        }

        public async Task UpdateCar(CarProductEntity updatedCar)
        {
            using (var context = new AMXDbContext())
            {
                context.Entry(updatedCar).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteCarById(long id)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    var car = await context.Cars.FindAsync(id);
                    if (car == null)
                    {
                        throw new InvalidOperationException("Car not found.");
                    }

                    context.Cars.Remove(car);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error when deleting car");
                }
            }
        }

        private long GenerateUniqueId(AMXDbContext context)
        {
            if (!context.Cars.Any())
            {
                return 1;
            }

            long id = context.Cars.Max(q => q.Id) + 1;
            return id;
        }
    }
}