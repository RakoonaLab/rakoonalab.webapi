using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.services.Entities.Models;

namespace rakoona.services.Mappers
{
    public static class ClinicaMapper
    {
        public static Clinica CreateFromRequest(this CreateClinicaRequest request, string userId)
        {
            Clinica clinica = new Clinica
            {
                ExternalId = Guid.NewGuid().ToString(),
                Nombre = request.Nombre,
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
                Direccion = "",
                Telefono = "",
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
