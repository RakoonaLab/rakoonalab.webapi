using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models.TiposDeContacto
{
    public class Contacto : ModelBase
    {
        public string ContactType { get; set; }
        public string Valor { get; set; }

        public int PersonaRef { get; set; }
        public Persona Persona { get; set; }
    }
}
