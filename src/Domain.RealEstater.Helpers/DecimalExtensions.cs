namespace Domain.RealEstater.Helpers
{
    public static class DecimalExtensions
    {
        public static bool IsWithin(this decimal radius, decimal x, decimal y, decimal a, decimal b)
        {
            return (x - a) * (x - a) + (y - b) * (y - b) <= radius * radius;
        }
    }
}