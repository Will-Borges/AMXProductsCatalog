namespace AMXProductsCatalog.Core.Domain.Domains.Generics.Ramdom
{
    public static class RandomIdGenerator
    {
        private static readonly Random rand = new Random();

        public static long GenerateId()
        {
            return rand.Next(10000, 99999);
        }
    }
}
