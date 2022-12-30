namespace rakoona.models.dtos.Request.Domicilio
{
    public class UpdateDomicilioRequest
    {
        public string? Calle { get; set; }
        public string? Colonia { get; set; }
        public string? Municipio { get; set; }
        public string? Estado { get; set; }
        public string? CP { get; set; }
    }
}
