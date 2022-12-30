using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models
{
    public class Domicilio : ModelBase
    {
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CP { get; set; }
        public bool Principal { get; set; }

        public int PersonaRef { get; set; }
        public PersonaBase Persona { get; set; }

    }
}
