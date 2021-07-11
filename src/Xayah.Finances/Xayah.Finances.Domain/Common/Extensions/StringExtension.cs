using System;

namespace Xayah.Finances.Domain.Common.Extension
{
    public static class StringExtension
    {
        public static string ToCamelCase(this string str)
        {
            return string.IsNullOrEmpty(str) || str.Length < 2 ? str : char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public static bool IsEqual(this string field, string otherField, bool ignoreCase = true)
        {
            if (field == null && otherField == null)
            {
                return true;
            }
            else
            {
                if (field == null ^ otherField == null)
                {
                    return false;
                }

                return field.Equals(otherField, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
            }
        }
    }
}