namespace rakoona.models.dtos.Request.Consultas
{
    public class CreateConsultaPreventivaRequest
    {
        public DateTime Fecha { get; internal set; }
        public double? Peso { get; internal set; }
        public double? Temperatura { get; internal set; }
        public string? Motivo { get; internal set; }
        public string? Observaciones { get; internal set; }
    }
}
