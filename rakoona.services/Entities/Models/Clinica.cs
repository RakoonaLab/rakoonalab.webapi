using rakoona.services.Entities.Models.Seguridad;

namespace rakoona.services.Entities.Models
{
    public class Clinica : ModelBase
    {
        public string UserRef { get; set; }
        public virtual User Usuario { get; set; }

        public string Nombre { get; set; }

        public ICollection<ClinicaMedico> ClinicaMedicos { get; set; }
        public ICollection<ClienteClinica> ClienteClinicas { get; set; }

    }
}
