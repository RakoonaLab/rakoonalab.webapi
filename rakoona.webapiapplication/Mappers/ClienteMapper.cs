using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;

namespace rakoona.webapiapplication.Mappers
{
    public static class ClienteMapper
    {
        public static PersonaBase CreateFromRequest(this CreateClienteRequest request, string userId)
        {
            PersonaBase Cliente = new PersonaBase
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now
            };
            return Cliente;
        }

        public static ClienteResponse MapToResponse(this PersonaBase entity)
        {
            ClienteResponse response = new ClienteResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
