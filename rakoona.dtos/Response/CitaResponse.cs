namespace rakoona.dtos.Response
{
    public class CitaResponse
    {
        public string Id { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string Fecha { get; set; }
        public string? MascotaId { get; set; }
        public string? MascotaNombre { get; set; }
        public string? DuenioId { get; set; }
        public string DuenioNombre { get; set; }
    }
}
