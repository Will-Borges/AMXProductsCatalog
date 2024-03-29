namespace AMXProductsCatalog.Core.Domain.Domains.Paginates
{
    public static class Pagination
    {
        public static T[] GetPage<T>(int pageSize, int pageNumber, T[]? query)
        {
            if (query == null)
            {
                return Array.Empty<T>();
            }

            int skipCount = (pageNumber - 1) * pageSize;
            var result = query.Skip(skipCount).Take(pageSize).ToArray();

            return result;
        }
    }
}
