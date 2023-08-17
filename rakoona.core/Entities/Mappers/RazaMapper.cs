using rakoona.core.Entities.Models.Pacientes;
using rakoona.dtos.Response;

namespace rakoona.core.Entities.Mappers
{
    internal static class RazaMapper
    {

        internal static RazaResponse MapToResponse(this RazaAnimal entity)
        {

            RazaResponse response = new RazaResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                NombreCientifico = entity.NombreCientifico,
                NombreColoquial = entity.NombreColoquial,
            };

            return response;
        }
    }
}
