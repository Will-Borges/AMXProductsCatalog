using Microsoft.EntityFrameworkCore;

namespace AMXProductsCatalog.Adapters.Persistence.Data
{
    using AMXProductsCatalog.Core.Domain.Entities.Products;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public class AMXDbContext : DbContext
    {
        public DbSet<CarProductEntity> Cars { get; set; }
        public DbSet<StockEntity> Stocks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
        }
    }
}
