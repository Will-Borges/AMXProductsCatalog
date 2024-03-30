using Microsoft.EntityFrameworkCore;

namespace AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Products
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Paginates;
    using AMXProductsCatalog.Core.Domain.Entities.Products;

    public class CarProductRepository : ICarProductRepository
    {
        private readonly AMXDbContext _context;

        public CarProductRepository(AMXDbContext context)
        {
            _context = context;
        }

        public async Task<long> InsertCarProduct(CarProductEntity car)
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();

                car.Id = GenerateUniqueId(_context);

                _context.Cars.Add(car);

                await _context.SaveChangesAsync();
                return car.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inserting car.");
            }

        }

        public async Task<CarProductEntity[]> GetAllCars(int pageSize, int pageNumber)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    var query = context.Cars.OrderBy(c => c.Id);

                    if (pageSize <= 0 || pageNumber <= 0)
                    {
                        return await query.ToArrayAsync();
                    }

                    var pagedQuery = Pagination.GetPage(pageSize, pageNumber, query);
                    return await pagedQuery.ToArrayAsync();
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
                    var car = await context.Cars.FindAsync(id);

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
        }

        public async Task<bool> UpdateCar(CarProductEntity updatedCar)
        {
            using (var context = new AMXDbContext())
            {
                try
                {
                    context.Entry(updatedCar).State = EntityState.Modified;
                    int affectedRows = await context.SaveChangesAsync();

                    return affectedRows > 0;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error when updating query.");
                }
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
                        return false;
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
