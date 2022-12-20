using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.Pacientes
{
    public class Mascota : PacienteBase
    {
        public int DuenioRef { get; set; }
        public virtual Cliente Duenio { get; set; }
        public List<ConsultaBase> Consultas { get; set; }
    }
}
