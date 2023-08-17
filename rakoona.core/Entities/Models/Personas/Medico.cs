using rakoona.core.Entities.Models.Consultas;

namespace rakoona.core.Entities.Models.Personas
{
    public class Medico : ModelBase
    {
        public int PersonaRef { get; set; }
        public PersonaBase? PersonaInfo { get; set; }

        public ICollection<ClinicaMedico>? ClinicaMedicos { get; set; }
        public ICollection<Consulta>? Consultas { get; set; }
        public ICollection<PlanDeVacunacion>? Vacunas { get; set; }
    }
}
