using rakoona.webapiapplication.Entities.Models.Seguridad;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapiapplication.Entities.Models.Personas
{
    public class PersonaBase : ModelBase
    {
        [Column("PrimerNombre")]
        public string PrimerNombre { get; set; }

        [Column("SegundoNombre")]
        public string SegundoNombre { get; set; }

        [Column("PrimerApellido")]
        public string PrimerApellido { get; set; }

        [Column("SegundoApellido")]
        public string SegundoApellido { get; set; }

        [Column("Nacimiento")]
        public DateTime Nacimiento { get; set; }
        

        public string? UsuarioRef { get; set; }
        public virtual User User { get; set; }

    }
}
