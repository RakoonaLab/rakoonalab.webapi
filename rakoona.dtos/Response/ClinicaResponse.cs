namespace rakoona.dtos.Response
{
    public class ClinicaResponse : IResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDeCreacion { get; set; }

    }
}
