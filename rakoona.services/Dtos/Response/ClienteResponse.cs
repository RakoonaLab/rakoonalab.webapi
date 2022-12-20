namespace rakoona.services.Dtos.Response
{
    public class ClienteResponse
    {
        public string Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Celular { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
    }
}
