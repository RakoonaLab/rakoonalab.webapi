namespace rakoona.webapiapplication.Entities.Dtos.Response
{
    public class PagedResponse<T>
    {
        public int Count { get; set; }
        public T Items { get; set; }
    }
}
