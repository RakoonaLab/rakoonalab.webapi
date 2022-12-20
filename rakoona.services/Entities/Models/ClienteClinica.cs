using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models
{
    public class ClienteClinica
    {
        public int Id { get; internal set; }

        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }
        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
    }
}
