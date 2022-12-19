using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Personas;
using System.Text;

namespace rakoona.services.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente CreateFromRequest(this CreateClienteRequest request, int clinicaId)
        {
            ClienteClinica clienteClinica = new ClienteClinica
            {
                ClinicaId = clinicaId,
            };

            Cliente Cliente = new Cliente
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                PrimerNombre = request.PrimerNombre,
                SegundoNombre = request.SegundoNombre,
                PrimerApellido = request.PrimerApellido,
                SegundoApellido = request.SegundoApellido,
                Direccion = request.Direccion,
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
                NombreCompleto = entity.NombreCompleto,
                FechaDeCreacion = entity.FechaDeCreacion,
                PrimerNombre = entity.PrimerNombre,
                SegundoNombre = entity.SegundoNombre,
                PrimerApellido = entity.PrimerApellido,
                SegundoApellido = entity.SegundoApellido,
                Direccion = entity.Direccion,
            };
            return response;
        }
    }
}
