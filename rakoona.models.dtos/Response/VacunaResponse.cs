namespace rakoona.models.dtos.Response
{
    public class VacunaResponse : IResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Laboratorio { get; set; }
        public string? Caducidad { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
        public double? Peso { get; set; }
        public string? Lote { get; set; }
        public double Temperatura { get; set; }
        public string? Fecha { get; set; }
        public string? MedicoId { get; set; }
        public string? MedicoNombre { get; set; }
        public string? MascotaId { get; set; }
        public string? MascotaNombre { get; set; }
        public string? DuenioId { get; set; }
        public string DuenioNombre { get; set; }
    }
}
