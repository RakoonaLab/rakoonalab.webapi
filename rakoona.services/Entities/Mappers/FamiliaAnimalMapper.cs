using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Mappers
{
    internal static class FamiliaAnimalMapper
    {
        
        internal static FamiliaResponse MapToResponse(this Familia entity)
        {

            FamiliaResponse response = new FamiliaResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                Nombre = entity.Nombre,
            };

            return response;
        }
    }
}
