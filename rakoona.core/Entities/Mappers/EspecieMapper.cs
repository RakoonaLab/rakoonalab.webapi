using rakoona.models.dtos.Response;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Mappers
{
    internal static class EspecieMapper
    {
        
        internal static EspecieResponse MapToResponse(this Especie entity)
        {

            EspecieResponse response = new EspecieResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                NombreCientifico = entity.NombreCientifico,
                NombreCorto = entity.NombreCorto,
            };

            return response;
        }
    }
}
