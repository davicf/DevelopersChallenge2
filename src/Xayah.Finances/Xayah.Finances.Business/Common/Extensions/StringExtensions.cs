using System;
using System.Globalization;

namespace Xayah.Finances.Business.Common.Extensions
{
    public static class StringExtensions
    {
        public static string GetValueLine(this string content)
        {
            var valueLine = content.Split(">").GetValue(1);

            return valueLine.ToString();
        }

        public static DateTime GetValueDateLine(this string content)
        {
            var valueLine = content.Split(">").GetValue(1);

            var valueDateLine = valueLine.ToString()
                                         .Split("[")
                                         .GetValue(0)
                                         .ToString()
                                         .Substring(0, 8);

            var valueDate = DateTime.ParseExact(valueDateLine, "yyyyMMdd", CultureInfo.InvariantCulture);

            return valueDate;
        }
    }
}