using rakoona.services.Entities.Models.Pacientes;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.Consultas
{
    public class Consulta : ModelBase
    {
        public Consulta() { }   

        public DateTime FechaAplicacion { get; set; }

        public double? Peso { get; set; }
        public double? Temperatura { get; set; }
        public int? RitmoCardiaco { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public int? Pulso { get; set; }
        public string? CaracteristicasDelPulso { get; set; }
        public string? Observaciones { get; set; }
        public string? Motivo { get; set; }
        public string? Diagnostico { get; set; }

        public int MedicoRef { get; set; }
        public virtual Medico? Medico { get; set; }

        public int MascotaRef { get; set; }
        public virtual Mascota? Mascota { get; set; }
        public virtual List<Vacunacion>? Vacunas { get; set; }
        
    }
}
