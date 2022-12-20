using Microsoft.AspNetCore.Identity;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.Seguridad
{
    public class User : IdentityUser
    {
        public List<Clinica> Clinicas { get; set; }
        public virtual PersonaBase Persona { get; set; }
    }
}
