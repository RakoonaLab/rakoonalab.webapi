namespace rakoona.models.dtos.Request
{
    public class CreateVacunaRequest
    {
        public string Nombre { get; set; }
        public string? Lote { get; set; }
        public string? Laboratorio { get; set; }
        public string? Caducidad { get; set; }
        public string? Observaciones { get; set; }
        public string MedicoId { get; set; }
        public string Fecha { get; set; }

        public int? Pulso { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public double? Peso { get; set; }
        public int? RitmoCardiaco { get; set; }
        public double? Temperatura { get; set; }
    }
}
