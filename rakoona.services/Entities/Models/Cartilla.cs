using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Pacientes;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models
{
    public class Cartilla : ModelBase
    {
        public int MascotaRef { get; set; }
        public virtual Mascota? Mascota { get; set; }

        public virtual List<Consulta>? Consultas { get; set; }
        public virtual List<Vacunacion>? Vacunas { get; set; }

    }
}
