using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDorms.Common
{
    public static class Helpers
    {
        public static IEnumerable<T> SortGrid<T>(IEnumerable<T> query, string orderColumn, string orderDirection)
        {
            var propertyInfoDefault = typeof(T).GetProperties().FirstOrDefault();
            var propertyInfo = typeof(T).GetProperty(orderColumn);

            if (propertyInfo != null)
            {
                var response = orderDirection.Equals("desc", StringComparison.InvariantCultureIgnoreCase)
                ? query.OrderByDescending(x => propertyInfo.GetValue(x, null))
                : query.OrderBy(x => propertyInfo.GetValue(x, null));

                return response;
            }
            else
            {
                return orderDirection.Equals("desc", StringComparison.InvariantCultureIgnoreCase)
                    ? query.OrderByDescending(x => propertyInfoDefault.GetValue(x, null))
                    : query.OrderBy(x => propertyInfoDefault.GetValue(x, null));
            }

        }
    }
}
