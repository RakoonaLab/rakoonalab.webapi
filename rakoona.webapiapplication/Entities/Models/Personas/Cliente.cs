using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Pacientes;

namespace rakoona.webapiapplication.Entities.Models.Personas
{
    public class Cliente : PersonaBase
    {
        public List<Mascota> Mascotas { get; set; }
        public List<ClienteClinica> ClienteClinicas { get;  set; }
    }
}
