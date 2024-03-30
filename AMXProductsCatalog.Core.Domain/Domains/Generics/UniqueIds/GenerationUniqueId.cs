using AMXProductsCatalog.Core.Domain.Domains.Products;
using System.Data.Entity;

namespace AMXProductsCatalog.Core.Domain.Domains.Generics.UniqueIds
{
    public static class GenerationUniqueId
    {
        public static long GenerateUniqueId<T>(DbSet<T> contextDbSet)
            where T : class, IEntity
        {
            if (!contextDbSet.Any())
            {
                return 1;
            }

            long id = contextDbSet.Max(q => q.Id) + 1;
            return id;
        }
    }
}
