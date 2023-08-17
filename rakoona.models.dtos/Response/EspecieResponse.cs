namespace rakoona.models.dtos.Response
{
    public class EspecieResponse
    {
        public string Id { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? NombreCientifico { get; set; }
        public string? NombreCorto { get; set; }
    }
}
