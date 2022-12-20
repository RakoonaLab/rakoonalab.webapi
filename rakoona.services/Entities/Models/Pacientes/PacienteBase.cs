namespace rakoona.services.Entities.Models.Pacientes
{
    public class PacienteBase : ModelBase
    {
        public string Nombre { get; set; }
        public string? Genero { get; set; }

        public int? DiaNacimiento { get; set; }
        public int? MesNacimiento { get; set; }
        public int? AnioNacimiento { get; set; }
    }
}
