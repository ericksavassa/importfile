namespace ImportFile.Domain.Common.Extensions
{
    public static class StringToDoubleExtension
    {
        public static double ToDouble(this string value)
        {
            if (value == null)
                return 0;

            double.TryParse(value, out double valueDouble);
            if (double.IsNaN(valueDouble) || double.IsInfinity(valueDouble))
                return 0;

            return valueDouble;
        }
    }
}