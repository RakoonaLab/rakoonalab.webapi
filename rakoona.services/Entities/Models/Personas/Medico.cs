using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Models.Personas
{
    public class Medico : PersonaBase
    {
        public ICollection<ClinicaMedico> ClinicaMedicos { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}
