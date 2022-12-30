namespace rakoona.models.dtos.Response
{
    public class VacunaResponse : IResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Laboratorio { get; set; }
        public DateTime? Caducidad { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
        public double? Peso { get; set; }
    }
}
