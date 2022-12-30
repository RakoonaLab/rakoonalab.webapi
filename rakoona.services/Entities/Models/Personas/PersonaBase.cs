using rakoona.services.Entities.Models.Seguridad;
using rakoona.services.Entities.Models.TiposDeContacto;
using System.Text;

namespace rakoona.services.Entities.Models.Personas
{
    public class PersonaBase : ModelBase
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string? UsuarioRef { get; set; }
        public virtual User? User { get; set; }
        public List<Contacto>? InformacionDeContacto { get; set; }
        public List<Domicilio>? Domicilios { get; set; }

        public string GetNombreCompleto()
        {
            var nombreCompleto = Nombres;
            nombreCompleto += Apellidos != "" ? " " + Apellidos : Apellidos;
            return nombreCompleto;
        }
    }
}
