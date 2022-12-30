namespace rakoona.models.dtos.Response.Consultas
{
    public class ConsultaPreventivaResponse : IResponse
    {
        public string? Id { get; set; }
        public string? FechaDeCreacion { get; set; }
        public string? Fecha { get; set; }
        public double? Peso { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
        public string? MascotaNombre { get; set; }
        public string? MascotaId { get; set; }
        public string? ClienteNombre { get; set; }
        public string? ClienteId { get; set; }
    }
}
