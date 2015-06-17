using System;
using System.Globalization;

namespace SinosPark.Utility
{
    public static class ExtensionMethods
    {
        public static string GetMonthName(this int month)
        {
            return new DateTime(2010, month, 1).ToString("MMMM", CultureInfo.CurrentCulture);
        } 
    }
}