using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.TiposDeContacto
{
    public class Contacto : ModelBase
    {
        public string ContactType { get; set; }
        public string Valor { get; set; }

        public int PersonaRef { get; set; }
        public PersonaBase Persona { get; set; }
    }
}
