using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models;

namespace rakoona.webapiapplication.Mappers
{
    public static class ClinicaMapper
    {
        public static Clinica CreateFromRequest(this CreateClinicaRequest request, string userId)
        {
            Clinica clinica = new Clinica
            {
                ExternalId = Guid.NewGuid().ToString(),
                Nombre = request.Nombre,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                FechaDeCreacion = DateTime.Now,
                UserRef = userId
            };
            return clinica;
        }

        public static ClinicaResponse MapToResponse(this Clinica entity)
        {
            ClinicaResponse response = new ClinicaResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                Direccion = entity.Direccion,
                Telefono = entity.Telefono,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
