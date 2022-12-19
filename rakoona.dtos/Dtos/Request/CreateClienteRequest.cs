namespace rakoona.services.Dtos.Request
{
    public class CreateClienteRequest
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
