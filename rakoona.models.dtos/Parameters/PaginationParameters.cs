namespace rakoona.models.dtos.Parameters
{
    public class PaginationParameters
    {
        public PaginationParameters(int? pageSize, int? page)
        {
            PageSize = pageSize ?? 10;
            Page = page ?? 1;
        }

        public int PageSize { get; }
        public int Page { get; }
    }
}
