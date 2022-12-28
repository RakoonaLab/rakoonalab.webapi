namespace rakoona.models.dtos.Request
{
    public class CreateVacunaRequest
    {
        
        public double? Peso { get; set; }
        public double? Temperatura { get; set; }

        public string? Nombre { get; set; }
        public string? Lote { get; set; }
        public string? Laboratorio { get; set; }
        public DateOnly? Caducidad { get; set; }
        public string Observaciones { get; set; }
    }
}
