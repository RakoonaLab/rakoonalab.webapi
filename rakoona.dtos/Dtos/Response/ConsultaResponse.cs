namespace rakoona.services.Dtos.Response
{
    public class ConsultaResponse
    {
        public string Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Observaciones { get; set; }
        public string? Diagnostico { get; set; }
        public string? Motivo { get; set; }
        public double? Temperatura { get; set; }
        public int? RitmoCardiaco { get; set; }
        public double? Peso { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public string? CaracteristicasDelPulso { get; set; }
        public int? Pulso { get; set; }
        public DateTime Fecha { get; set; }
        public string? MascotaId { get; set; }
        public string? MascotaNombre { get; set; }
        public string? ClienteNombre { get; set; }
        public string? ClienteId { get; set; }
    }
}
