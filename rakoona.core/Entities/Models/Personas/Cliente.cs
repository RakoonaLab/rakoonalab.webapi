using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Personas
{
    public class Cliente : Persona
    {
        public List<Mascota> Mascotas { get; set; }
        public List<ClienteClinica> ClienteClinicas { get; set; }

    }
}
