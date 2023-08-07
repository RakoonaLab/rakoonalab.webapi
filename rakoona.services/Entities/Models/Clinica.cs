namespace rakoona.services.Entities.Models
{
    public class Clinica : ModelBase
    {
        public int OrganizacionRef { get; set; }
        public virtual Organizacion Organizacion { get; set; }

        public string Nombre { get; set; }

        public ICollection<ClinicaMedico> ClinicaMedicos { get; set; }
        public ICollection<ClienteClinica> ClienteClinicas { get; set; }

    }
}
