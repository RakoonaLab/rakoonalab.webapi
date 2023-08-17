using rakoona.models.dtos.Request.Clientes;
using rakoona.models.dtos.Response;
using rakoona.core.Entities.Models;
using rakoona.core.Entities.Models.Personas;
using rakoona.core.Entities.Models.TiposDeContacto;

namespace rakoona.core.Entities.Mappers
{
    internal static class ClienteMapper
    {
        internal static Cliente CreateFromRequest(this CreateClienteRequest request, int clinicaId)
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

        internal static Cliente CreateFromRequest(this UpdateClienteRequest request, Cliente cliente)
        {
            cliente.Nombres = request.Nombres;
            cliente.Apellidos = request.Apellidos;

            return cliente;
        }

        internal static ClienteResponse MapToResponse(this Cliente entity)
        {
            var celular = entity.InformacionDeContacto?.FirstOrDefault(x => x.ContactType == "Celular")?.Valor;
            var domicilio = entity.Domicilios?.FirstOrDefault(x => x.Principal);

            ClienteResponse response = new ClienteResponse
            {
                Id = entity.ExternalId,
                NombreCompleto = entity.GetNombreCompleto(),
                FechaDeCreacion = entity.FechaDeCreacion,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Celular = celular,
                Mascotas = entity.Mascotas?.Select(x => x.MapToResponse()),
                Domicilio = domicilio != null ? domicilio.Calle + ", " + domicilio.Colonia + ", " + domicilio.Municipio + ", " + domicilio.Estado + ", " + domicilio.CP : ""
            };
            return response;
        }
    }
}
