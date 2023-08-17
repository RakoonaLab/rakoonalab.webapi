using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Mappers
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
