using System.Collections.Generic;

namespace Quasar.Collections.Paging
{
    public interface IPagedList<out T>
    {
        int PageSize { get; }
        int TotalCountOfItems { get; }
        IEnumerable<T> CurrentPageItems { get; }
        int CurrentPageNumber { get; }
        int TotalCountOfPages { get; }
        int CurrentPageFirstItemIndex { get; }
        int CurrentPageLastItemIndex { get; }
    }
}