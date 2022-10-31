namespace rakoona.webapiapplication.Entities.Dtos.Request
{
    public class CreateClienteRequest
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public object Email { get;  set; }
        public DateTime? Nacimiento { get;  set; }
        public string PrimerNombre { get;  set; }
        public string SegundoNombre { get;  set; }
        public string PrimerApellido { get;  set; }
        public string SegundoApellido { get;  set; }
    }
}
