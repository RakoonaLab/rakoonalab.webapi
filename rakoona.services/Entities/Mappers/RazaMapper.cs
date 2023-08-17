using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Mappers
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
