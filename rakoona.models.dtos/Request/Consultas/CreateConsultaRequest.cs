namespace rakoona.models.dtos.Request.Consultas
{
    public class CreateConsultaRequest
    {
        public int? Pulso { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public double? Peso { get; set; }
        public int? RitmoCardiaco { get; set; }
        public double? Temperatura { get; set; }

        public string? Motivo { get; set; }
        public string? Diagnostico { get; set; }
        public string? Observaciones { get; set; }
        public string MedicoId { get; set; }
        public string Fecha { get; set; }
    }
}
