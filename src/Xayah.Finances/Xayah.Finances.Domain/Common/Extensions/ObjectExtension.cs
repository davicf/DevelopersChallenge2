using System.Collections.Generic;
using System.Linq;

namespace Xayah.Finances.Domain.Common.Extension
{
    public static class ObjectExtension
    {
        public static bool IsNull<T>(this T obj) =>
            Equals(obj, default(T));

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj) =>
            Equals(obj, default(IEnumerable<T>)) || !obj.Any();
    }
}