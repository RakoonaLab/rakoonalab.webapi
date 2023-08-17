using rakoona.core.Entities.Models.TiposDeContacto;
using rakoona.dtos.Request.InformacionDeContacto;
using rakoona.dtos.Response;

namespace rakoona.core.Entities.Mappers
{
    internal static class CelularMapper
    {
        internal static CelularResponse MapToResponse(this Contacto entity)
        {
            CelularResponse response = new CelularResponse
            {
                Id = entity.ExternalId,
                Valor = entity.Valor
            };
            return response;
        }

        internal static Contacto UpdateFromRequest(this UpdateCelularRequest request, Contacto contacto)
        {
            contacto.Valor = request.Valor;

            return contacto;
        }
    }
}
