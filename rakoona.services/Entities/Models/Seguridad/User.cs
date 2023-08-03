using Microsoft.AspNetCore.Identity;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.Seguridad
{
    public class User : IdentityUser
    {
        public virtual UsuarioOrganizacion UsuarioOrganizacion { get; set; }
        public virtual PersonaBase Persona { get; set; }
    }
}
