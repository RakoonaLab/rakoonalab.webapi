namespace rakoona.webapiapplication.Entities.Dtos.Request
{
    public class CreateMedicoRequest
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nacimiento { get; set; }
    }
}
