namespace rakoona.services.Entities.Models.Consultas
{
    public class ConsultaBasica : ConsultaBase
    {
        public double? Temperatura { get; set; }
        public int? RitmoCardiaco { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public int? Pulso { get; set; }
        public string? CaracteristicasDelPulso { get; set; }
        public string? Diagnostico { get; set; }
    }
}
