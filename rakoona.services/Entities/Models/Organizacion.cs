namespace rakoona.services.Entities.Models
{
    public class Organizacion : ModelBase
    {
        public virtual UsuarioOrganizacion UsuarioOrganizacion { get; set; }
        public ICollection<Clinica> Clinicas { get; set; }
    }
}
