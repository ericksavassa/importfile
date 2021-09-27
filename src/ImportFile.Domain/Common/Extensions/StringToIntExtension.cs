using System;
using System.Globalization;

namespace ImportFile.Domain.Common.Extensions
{
    public static class StringToIntExtension
    {
        public static Int32 ToInt32(this string value)
        {
            try
            {
                return Int32.Parse(
                    value,
                    NumberStyles.Integer,
                    CultureInfo.CurrentCulture.NumberFormat);
            }
            catch
            {
                return 0;
            }
        }
    }
}