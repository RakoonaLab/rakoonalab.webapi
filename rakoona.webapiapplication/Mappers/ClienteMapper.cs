using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;

namespace rakoona.webapiapplication.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente CreateFromRequest(this CreateClienteRequest request,int clinicaId)
        {
            ClienteClinica clienteClinica = new ClienteClinica {
                 ClinicaId = clinicaId,
            };

            Cliente Cliente = new Cliente
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                ClienteClinicas = new List<ClienteClinica> {
                    clienteClinica
                } 
            };
            return Cliente;
        }

        public static ClienteResponse MapToResponse(this Cliente entity)
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
