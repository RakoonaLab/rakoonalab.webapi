namespace rakoona.services.Entities.Models.Personas
{
    public class Medico : PersonaBase
    {
        public ICollection<ClinicaMedico> ClinicaMedicos { get; set; }
    }
}
