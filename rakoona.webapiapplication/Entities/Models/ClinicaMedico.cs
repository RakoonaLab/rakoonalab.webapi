using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Personas;

namespace rakoona.webapi.Entities.Models
{
    public class ClinicaMedico
    {
        public int Id { get; internal set; }

        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }
        
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        
    }
}
