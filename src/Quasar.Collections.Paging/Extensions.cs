using System.Collections.Generic;
using System.Linq;

namespace Quasar.Collections.Paging
{
    public static class Extensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> items, int pageSize, int currentPageNumber = 1, int? totalCount = null)
        {
            if (items == null) return null;

            var totalCountOfItems = totalCount ?? items.Count();

            var pagedList = new PagedList<T>(items, pageSize, totalCountOfItems, currentPageNumber);
            return pagedList;
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> items, int pageSize, int currentPageNumber = 1)
        {
            if (items == null) return null;

            var totalCountOfItems = items.Count();

            var pagedList = new PagedList<T>(items, pageSize, totalCountOfItems, currentPageNumber);
            return pagedList;
        }
    }
}