namespace rakoona.models.dtos.Request.Consultas
{
    public class UpdateConsultaRequest
    {
        public DateTime Fecha { get; internal set; }
        public int? Pulso { get; internal set; }
        public string? CaracteristicasDelPulso { get; internal set; }
        public int? FrecuenciaRespiratoria { get; internal set; }
        public double? Peso { get; internal set; }
        public int? RitmoCardiaco { get; internal set; }
        public double? Temperatura { get; internal set; }
        public string? Motivo { get; internal set; }
        public string? Diagnostico { get; internal set; }
        public string? Observaciones { get; internal set; }
    }
}
