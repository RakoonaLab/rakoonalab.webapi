using rakoona.webapiapplication.Entities.Models.Pacientes;

namespace rakoona.webapiapplication.Entities.Models.Personas
{
    public class Owner : PersonaBase
    {
        public List<Mascota> Mascotas { get; set; }
    }
}
