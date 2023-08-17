namespace rakoona.dtos.Request
{
    public class CreateMascotaRequest
    {
        public string Nombre { get; set; }
        public string? Genero { get; set; }
        public string? DiaNacimiento { get; set; }
        public string? MesNacimiento { get; set; }
        public string? AnioNacimiento { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public string? Colores { get; set; }
    }
}
