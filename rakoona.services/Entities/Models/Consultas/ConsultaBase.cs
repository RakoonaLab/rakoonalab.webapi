using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Models.Consultas
{
    public class ConsultaBase : ModelBase
    {
        public DateTime Fecha { get; set; }
        public double? Peso { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
        public int MascotaRef { get; set; }
        public double? Temperatura { get; set; }
        public int? RitmoCardiaco { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public int? Pulso { get; set; }
        public string? CaracteristicasDelPulso { get; set; }
        public string? Diagnostico { get; set; }
        public List<Receta> Recetas { get; set; }

        public virtual Mascota Mascota { get; set; }
        public List<Vacuna> Vacunas { get; set; }
    }
}

