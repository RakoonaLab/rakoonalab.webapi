using Microsoft.AspNetCore.Identity;
using rakoona.webapiapplication.Entities.Models.Personas;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rakoona.webapiapplication.Entities.Models.Seguridad
{
    [Table("IdentityUser")]
    public class User : IdentityUser
    {
        public List<Clinica> Clinicas { get; set; }

        public virtual PersonaBase Persona { get; set; }
    }
}
