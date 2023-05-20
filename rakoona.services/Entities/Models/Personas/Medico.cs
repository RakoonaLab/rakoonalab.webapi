using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Models.Personas
{
    public class Medico : ModelBase
    {
        public int PersonaRef { get; set; }
        public PersonaBase? PersonaInfo { get; set; }

        public ICollection<ClinicaMedico>? ClinicaMedicos { get; set; }
        public ICollection<Consulta>? Consultas { get; set; }
    }
}
