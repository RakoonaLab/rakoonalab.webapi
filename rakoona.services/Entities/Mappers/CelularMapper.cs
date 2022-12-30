using rakoona.models.dtos.Request.Clientes;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.TiposDeContacto;

namespace rakoona.services.Entities.Mappers
{
    public static class CelularMapper
    {
        public static CelularResponse MapToResponse(this Contacto entity)
        {
            CelularResponse response = new CelularResponse
            {
                Id = entity.ExternalId,
                Valor = entity.Valor
            };
            return response;
        }

        public static Contacto UpdateFromRequest(this UpdateCelularRequest request, Contacto contacto)
        {
            contacto.Valor = request.Valor;

            return contacto;
        }
    }
}
