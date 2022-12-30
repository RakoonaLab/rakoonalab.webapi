namespace rakoona.models.dtos.Response
{
    public class ClienteResponse : IResponse
    {
        public string Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Celular { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public IEnumerable<MascotaResponse> Mascotas { get; set; }
    }
}
