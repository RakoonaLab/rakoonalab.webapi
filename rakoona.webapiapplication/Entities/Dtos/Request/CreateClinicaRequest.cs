namespace rakoona.webapiapplication.Entities.Dtos.Request
{
    public class CreateClinicaRequest
    {
        public DateTime FechaDeCreacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
