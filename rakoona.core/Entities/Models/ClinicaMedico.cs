using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models
{
    public class ClinicaMedico
    {
        public int Id { get; internal set; }

        public int ClinicaId { get; set; }
        public Clinica? Clinica { get; set; }

        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }

    }
}
