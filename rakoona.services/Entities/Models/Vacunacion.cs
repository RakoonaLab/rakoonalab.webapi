using rakoona.services.Entities.Models.Pacientes;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models
{
    public class Vacunacion : AplicacionBase
    {
        public string Nombre { get; set; }
        public string? Lote { get; set; }
        public string? Laboratorio { get; set; }
        public DateTime? Caducidad { get; set; }


        public int MedicoRef { get; set; }
        public virtual Medico? Medico { get; set; }

        public int CartillaRef { get; set; }
        public virtual Cartilla? Cartilla { get; set; }
    }
}
