namespace rakoona.models.dtos.Response
{
    public class DomicilioResponse : IResponse
    {
        public string Id { get; set; }
        public string? DomicilioCompleto { get; set; }
        public string? Calle { get; set; }
        public string? Colonia { get; set; }
        public string? Municipio { get; set; }
        public string? Estado { get; set; }
        public string? CP { get; set; }
    }
}
