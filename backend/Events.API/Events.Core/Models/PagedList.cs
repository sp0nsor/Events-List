namespace Events.Core.Models
{
    public class PagedList<T>
    {
        private PagedList(
            List<T> items,
            int totalCount,
            int currentPage,
            int pageSize,
            int totalPage)
        {
            Items = items;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPage = totalPage;
        }

        public List<T> Items { get; }
        public int TotalCount { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public int TotalPage { get; }

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
