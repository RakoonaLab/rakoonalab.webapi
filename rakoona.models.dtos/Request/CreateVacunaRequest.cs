namespace rakoona.models.dtos.Request
{
    public class CreateVacunaRequest
    {
        public CreateVacunaRequest(string nombre)
        {
            Nombre = nombre;
        }

        public double? Peso { get; set; }
        public double? Temperatura { get; set; }
        public string Nombre { get; set; }
        public string? Lote { get; set; }
        public string? Laboratorio { get; set; }
        public string? Caducidad { get; set; }
        public string? Observaciones { get; set; }
        public string MedicoId { get; set; }
        public string Fecha { get; set; }
    }
}
