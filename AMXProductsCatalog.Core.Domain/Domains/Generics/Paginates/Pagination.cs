namespace AMXProductsCatalog.Core.Domain.Domains.Paginates
{
    public static class Pagination
    {
        public static IQueryable<T> GetPage<T>(int pageSize, int pageNumber, IQueryable<T>? query)
        {
            if (query == null)
            {
                return new List<T>().AsQueryable();
            }

            int skipCount = (pageNumber - 1) * pageSize;
            var result = query.Skip(skipCount).Take(pageSize);

            return result;
        }
    }
}
