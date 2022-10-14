using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Consultas;

namespace rakoona.webapiapplication.Entities.Models.Personas
{
    public class Medico : PersonaBase
    {
        public ICollection<ClinicaMedico> ClinicaMedicos { get; set; }
    }
}
