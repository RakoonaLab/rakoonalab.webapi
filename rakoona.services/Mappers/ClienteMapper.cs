using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Personas;
using rakoona.services.Entities.Models.TiposDeContacto;
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

            Cliente cliente = new Cliente
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                ClienteClinicas = new List<ClienteClinica> {
                    clienteClinica
                }
            };

            if (request.Celular != "")
            {
                cliente.InformacionDeContacto = new List<Contacto> {
                    new Celular { ExternalId = Guid.NewGuid().ToString(), Valor = request.Celular }
                };
            }

            return cliente;
        }

        public static ClienteResponse MapToResponse(this Cliente entity)
        {
            ClienteResponse response = new ClienteResponse
            {
                Id = entity.ExternalId,
                NombreCompleto = entity.GetNombreCompleto(),
                FechaDeCreacion = entity.FechaDeCreacion,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Celular = entity.InformacionDeContacto?.First(x => x.ContactType == "Celular")?.Valor
            };
            return response;
        }
    }
}
