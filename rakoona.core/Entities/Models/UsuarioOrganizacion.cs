using rakoona.core.Entities.Models.Seguridad;

namespace rakoona.core.Entities.Models
{
    public class UsuarioOrganizacion : ModelBase
    {
        public string UserRef { get; set; }
        public virtual User Usuario { get; set; }

        public int OrganizacionRef { get; set; }
        public virtual Organizacion Organizacion { get; set; }
    }
}
