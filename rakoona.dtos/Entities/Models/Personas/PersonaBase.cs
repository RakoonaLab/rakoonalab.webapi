using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Seguridad;

namespace rakoona.services.Entities.Models.Personas
{
    public class PersonaBase : ModelBase
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? Nacimiento { get; set; }
        public string? UsuarioRef { get; set; }
        public virtual User User { get; set; }

    }
}
