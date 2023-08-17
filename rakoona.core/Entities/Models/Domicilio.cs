﻿using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models
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
        public Persona Persona { get; set; }

    }
}
