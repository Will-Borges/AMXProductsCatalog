namespace AMXProductsCatalog.Core.Domain.Domains.Generics.Verification
{
    public static class ValueCheckerPresenter
    {
        public static void CheckFor<T>(T value)
        {
            if (value == null) throw new InvalidOperationException("The input values cannot be null.");
        }

        public static void CheckFor<T>(T[] value)
        {
            if (!value.Any()) throw new InvalidOperationException("The input values cannot be empty.");

            if (value == null) throw new InvalidOperationException("The input values cannot be null.");
        }

        public static void CheckFor(long value)
        {
            if (value == 0) throw new InvalidOperationException("The input values cannot be zero.");
        }

        public static void CheckFor(int value)
        {
            if (value == 0) throw new InvalidOperationException("The input values cannot be zero.");
        }
    }
}