using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Pacientes;
using rakoona.webapiapplication.Entities.Models.Personas;
using System.Text;

namespace rakoona.webapiapplication.Mappers
{
    public static class MascotaMapper
    {
        public static Mascota CreateFromRequest(this CreatePacienteRequest request, int? clienteId)
        {
            Mascota Paciente = new Mascota
            {
                Nombre = request.Nombre,
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now
            };

            if (clienteId != null)
                Paciente.DuenioRef = clienteId.Value;

            return Paciente;
        }

        public static PacienteResponse MapToResponse(this Mascota entity)
        {

            PacienteResponse response = new PacienteResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
