using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Entities.Models;

namespace rakoona.core.Entities.Mappers
{
    internal static class ClinicaMapper
    {
        internal static Clinica CreateFromRequest(this CreateClinicaRequest request, int organizacionId)
        {
            Clinica clinica = new Clinica
            {
                ExternalId = Guid.NewGuid().ToString(),
                Nombre = request.Nombre,
                FechaDeCreacion = DateTime.Now,
                OrganizacionRef = organizacionId
            };
            return clinica;
        }

        internal static ClinicaResponse MapToResponse(this Clinica entity)
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
