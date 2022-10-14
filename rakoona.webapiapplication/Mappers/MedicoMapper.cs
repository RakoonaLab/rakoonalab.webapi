using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;

namespace rakoona.webapiapplication.Mappers
{
    public static class MedicoMapper
    {
        public static Medico CreateFromRequest(this CreateMedicoRequest request, string userId)
        {
            Medico medico = new Medico
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now
            };
            return medico;
        }

        public static MedicoResponse MapToResponse(this Medico entity)
        {
            MedicoResponse response = new MedicoResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.PrimerNombre,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
