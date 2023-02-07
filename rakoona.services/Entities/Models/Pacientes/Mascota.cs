using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Models.Pacientes
{
    public class Mascota : ModelBase
    {
        public string Nombre { get; set; }
        public string? Genero { get; set; }
        public int? DiaNacimiento { get; set; }
        public int? MesNacimiento { get; set; }
        public int? AnioNacimiento { get; set; }
        public int DuenioRef { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }

        public List<ColorPorMascota>? Colores { get; set; }
        public virtual Cliente? Duenio { get; set; }
        public virtual List<Consulta>? Consultas { get; set; }
    }
}
