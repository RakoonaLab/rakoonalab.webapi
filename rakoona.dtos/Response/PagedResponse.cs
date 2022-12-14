namespace rakoona.dtos.Response
{
    public class PagedResponse<T>
    {
        public int Count { get; set; }
        public T Items { get; set; }
    }
}
