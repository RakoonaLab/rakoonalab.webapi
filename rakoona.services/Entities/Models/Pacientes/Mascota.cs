using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Consultas.Mediciones;
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

        public virtual Cliente? Duenio { get; set; }
        public virtual Cartilla Cartilla { get; set; }

        public virtual List<ColorPorMascota>? Colores { get; set; }
        public virtual List<ImagenPorMascota>? Imagenes { get; set; }

        
        public virtual List<MedicionDePeso>? MedicionesDePeso { get; set; }
        public virtual List<MedicionDePulso>? MedicionesDePulso { get; set; }
        public virtual List<MedicionDeRitmoCardiaco>? MedicionesDeRitmoCardiaco { get; set; }
        public virtual List<MedicionDeTemperatura>? MedicionesDeTemperatura { get; set; }
        public virtual List<MedicionDeFrecuenciaRespiratoria>? MedicionesDeFrecuenciaRespiratoria { get; set; }
        public virtual List<Cita>? Citas { get; set; }
    }
}
