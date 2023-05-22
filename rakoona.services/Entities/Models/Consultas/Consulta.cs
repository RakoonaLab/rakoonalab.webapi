using rakoona.services.Entities.Models.Consultas.Mediciones;
using rakoona.services.Entities.Models.Pacientes;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.Consultas
{
    public class Consulta : AplicacionBase
    {
        public Consulta() { }   

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
