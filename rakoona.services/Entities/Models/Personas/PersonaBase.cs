using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Seguridad;
using System.Text;

namespace rakoona.services.Entities.Models.Personas
{
    public class PersonaBase : ModelBase
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreCompleto
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (PrimerNombre != "")
                {
                    sb.Append(PrimerNombre + " ");
                }
                if (SegundoNombre != "")
                {
                    sb.Append(SegundoNombre + " ");
                }
                if (PrimerApellido != "")
                {
                    sb.Append(PrimerApellido + " ");
                }
                if (SegundoApellido != "")
                {
                    sb.Append(SegundoApellido);
                }
                string nombreCompleto = sb.ToString();
                if (nombreCompleto.EndsWith(" "))
                    nombreCompleto = nombreCompleto.Remove(nombreCompleto.Length - 1);
                return nombreCompleto;
            }
        }
        public DateTime? Nacimiento { get; set; }
        public string? UsuarioRef { get; set; }
        public virtual User User { get; set; }

    }
}
