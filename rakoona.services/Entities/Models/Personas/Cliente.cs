using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Models.Personas
{
    public class Cliente : PersonaBase
    {
        public List<Mascota> Mascotas { get; set; }
        public List<ClienteClinica> ClienteClinicas { get; set; }

    }
}
