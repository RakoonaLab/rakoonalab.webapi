using Microsoft.AspNetCore.Identity;
using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models.Seguridad
{
    public class User : IdentityUser
    {
        public virtual PersonaBase Persona { get; set; }
        public virtual Organizacion Organizacion { get; set; }
    }
}
