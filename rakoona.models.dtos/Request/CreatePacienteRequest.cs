namespace rakoona.models.dtos.Request
{
    public class CreatePacienteRequest
    {
        public string Nombre { get; set; }
        public string? Genero { get; set; }
        public int? DiaNacimiento { get; set; }
        public int? MesNacimiento { get; set; }
        public int? AnioNacimiento { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
    }
}
