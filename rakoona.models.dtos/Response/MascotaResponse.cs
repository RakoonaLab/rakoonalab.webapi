namespace rakoona.models.dtos.Response
{
    public class MascotaResponse : IResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Genero { get; set; }
        public string? Edad { get; set; }
        public string? FechaDeNacimiento { get; set; }
        public int? VacunasCount { get; set; }
        public double? Peso { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public string? DuenioNombre { get; set; }
        public string? DuenioId { get; set; }
        public IEnumerable<string>? Colores { get; set; }
    }
}
