using rakoona.core.Entities.Models.Seguridad;
using rakoona.core.Entities.Models.TiposDeContacto;

namespace rakoona.core.Entities.Models.Personas
{
    public class PersonaBase : ModelBase
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string? UsuarioRef { get; set; }
        public virtual User? User { get; set; }
        public virtual Medico? MedicoInfo { get; set; }
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
