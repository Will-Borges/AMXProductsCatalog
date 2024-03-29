using AMXProductsCatalog.Core.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AMXProductsCatalog.Adapters.Persistence.Data
{
    public class AMXDbContext : DbContext
    {
        public DbSet<CarProductEntity> Cars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
        }
    }
}
