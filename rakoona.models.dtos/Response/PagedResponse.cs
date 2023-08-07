namespace rakoona.models.dtos.Response
{
    public class PagedResponse<T>
    {
        public PagedResponse(int page, int pageSize, T items, int totalItems)
        {
            Page = page;
            PageSize = pageSize;
            Items = items;
            TotalItems = totalItems;
        }
        public int PageSize { get; }
        public int Page { get; }
        public T Items { get; }
        public int TotalItems { get; }
    }
}
