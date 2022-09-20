using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models;

namespace rakoona.webapiapplication.Mappers
{
    public static class ClinicaMapper
    {
        public static Clinica MapFromRequest(this CreateClinicaRequest request)
        {
            Clinica clinica = new Clinica
            {
                Nombre = request.Nombre,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                FechaDeCreacion = request.FechaDeCreacion,
            };
            return clinica;
        }

        public static ClinicaResponse MapToResponse(this Clinica entity)
        {
            ClinicaResponse response = new ClinicaResponse
            {
                Id= entity.ExternalId,
                Nombre = entity.Nombre,
                Direccion = entity.Direccion,
                Telefono = entity.Telefono,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
