using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Extentions
{
    public static class DistinctBy
    {
        public static IEnumerable<T> MyDistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
            return items.GroupBy(property).Select(x => x.First());
        }
    }
}
