namespace rakoona.dtos.Response
{
    public class Response : IResponse
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors{ get; set; }
    }
}
