using Microsoft.AspNetCore.Identity;
using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models.Seguridad
{
    public class User : IdentityUser
    {
        public virtual UsuarioOrganizacion UsuarioOrganizacion { get; set; }
        public virtual PersonaBase Persona { get; set; }
    }
}
