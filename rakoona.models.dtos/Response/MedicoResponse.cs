namespace rakoona.models.dtos.Response
{
    public class MedicoResponse : IResponse
    {
        public string? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Celular { get; set; }
        public DateTime FechaDeCreacion { get; set; }
    }
}
