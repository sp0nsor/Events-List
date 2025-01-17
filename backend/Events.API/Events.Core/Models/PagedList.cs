namespace Events.Core.Models
{
    public class PagedList<T>
    {
        private PagedList(
            List<T> items,
            int totalCount,
            int currentPage,
            int pageSize,
            int totalPages)
        {
            Items = items;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
        }

        public List<T> Items { get; }
        public int TotalCount { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public int TotalPages { get; }

        public static PagedList<T> Create(List<T> items,
            int totalCount, 
            int CurrentPage,
            int PageSize,
            int totalPages)
        {
            return new(items, totalCount, CurrentPage, PageSize, totalPages);
        }
    }
}
