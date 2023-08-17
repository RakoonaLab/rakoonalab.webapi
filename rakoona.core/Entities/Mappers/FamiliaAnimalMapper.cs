using rakoona.core.Entities.Models.Pacientes;
using rakoona.dtos.Response;

namespace rakoona.core.Entities.Mappers
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
