using rakoona.core.Entities.Models.Consultas;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models
{
    public class Cartilla : ModelBase
    {
        public int MascotaRef { get; set; }
        public virtual Mascota? Mascota { get; set; }

        public virtual List<Consulta>? Consultas { get; set; }
        public virtual List<PlanDeVacunacion>? PlanesDeVacunacion { get; set; }

    }
}
