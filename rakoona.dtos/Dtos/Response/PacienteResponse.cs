namespace rakoona.services.Dtos.Response
{
    public class PacienteResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Genero { get; set; }
        public string? Edad { get; set; }
        public string? FechaDeNacimiento { get; set; }
        public int? Vacunas { get; set; }
    }
}
