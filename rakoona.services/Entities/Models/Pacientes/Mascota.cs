using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.Pacientes
{
    public class Mascota : PacienteBase
    {
        public int DuenioRef { get; set; }
        public virtual Cliente? Duenio { get; set; }
        public virtual List<Consulta>? Consultas { get; set; }
        public string? Especie { get;  set; }
        public string? Raza { get;  set; }
    }
}
