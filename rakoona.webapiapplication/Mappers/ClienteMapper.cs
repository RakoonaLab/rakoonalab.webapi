using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Personas;
using System.Text;

namespace rakoona.webapiapplication.Mappers
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
            StringBuilder sb = new StringBuilder();
            if (entity.PrimerNombre != "")
            {
                sb.Append(entity.PrimerNombre + " ");
            }
            if (entity.SegundoNombre != "")
            {
                sb.Append(entity.SegundoNombre + " ");
            }
            if (entity.PrimerApellido != "")
            {
                sb.Append(entity.PrimerApellido + " ");
            }
            if (entity.SegundoApellido != "")
            {
                sb.Append(entity.SegundoApellido);
            }
            string nombreCompleto = sb.ToString();
            if (nombreCompleto.EndsWith(" "))
                nombreCompleto = nombreCompleto.Remove(nombreCompleto.Length - 1);

            ClienteResponse response = new ClienteResponse
            {
                Id = entity.ExternalId,
                NombreCompleto = nombreCompleto,
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
