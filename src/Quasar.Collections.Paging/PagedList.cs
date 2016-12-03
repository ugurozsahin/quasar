using System;
using System.Collections.Generic;
using System.Linq;

namespace Quasar.Collections.Paging
{
    public sealed class PagedList<T> : IPagedList<T>
    {
        public int PageSize { get; }
        public int TotalCountOfItems { get; }
        public IEnumerable<T> CurrentPageItems { get; private set; }
        public int CurrentPageNumber { get; private set; }
        public int TotalCountOfPages { get; private set; }

        public PagedList(IEnumerable<T> items, int pageSize, int totalCountOfItems, int currentPageNumber = 1)
        {
            if (currentPageNumber < 1) throw new InvalidOperationException("Invalid CurrentPageNumber Parameter");
            if (pageSize < 1) throw new InvalidOperationException("Invalid PageSize Parameter");

            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;
            TotalCountOfItems = totalCountOfItems;

            Initialize(items);
        }

        private void Initialize(IEnumerable<T> items)
        {
            TotalCountOfPages = TotalCountOfItems == 0 ? 1 : (TotalCountOfItems/PageSize + (TotalCountOfItems%PageSize > 0 ? 1 : 0));

            if (CurrentPageNumber > TotalCountOfPages)
                CurrentPageNumber = TotalCountOfPages;

            var itemsToSkip = (CurrentPageNumber - 1) * PageSize;
            CurrentPageItems = items.Skip(itemsToSkip).Take(PageSize).ToList();
        }

        public int CurrentPageFirstItemIndex => CurrentPageNumber > 1 ? ((CurrentPageNumber - 1) * PageSize) + 1 : 1;

        public int CurrentPageLastItemIndex => CurrentPageNumber == TotalCountOfPages ? TotalCountOfItems : (CurrentPageNumber * PageSize);
    }
}