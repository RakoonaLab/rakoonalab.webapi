using rakoona.core.Entities.Models.Pacientes;
using rakoona.dtos.Response;

namespace rakoona.core.Entities.Mappers
{
    internal static class GeneroAnimalMapper
    {

        internal static GeneroAnimalResponse MapToResponse(this GeneroAnimal entity)
        {

            GeneroAnimalResponse response = new GeneroAnimalResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                Nombre = entity.Nombre,
            };

            return response;
        }
    }
}
