using rakoona.models.dtos.Request.Domicilio;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Mappers
{
    internal static class DomicilioMapper
    {
        internal static Domicilio CreateFromRequest(this CreateDomicilioRequest request, int personaId)
        {
            Domicilio domicilio = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                Calle = request.Calle,
                FechaDeCreacion = DateTime.Now,
                Colonia = request.Colonia,
                Municipio = request.Municipio,
                Estado = request.Estado,
                CP = request.CP,
                Principal = request.Principal,
                PersonaRef = personaId
            };
            return domicilio;
        }

        internal static DomicilioResponse MapToResponse(this Domicilio entity)
        {
            DomicilioResponse response = new DomicilioResponse
            {
                Id = entity.ExternalId,
                Calle = entity.Calle,
                Colonia = entity.Colonia,
                Municipio = entity.Municipio,
                Estado = entity.Estado,
                CP = entity.CP
            };
            return response;
        }

        internal static Domicilio UpdateFromRequest(this UpdateDomicilioRequest request, Domicilio domicilio)
        {
            domicilio.Calle = request.Calle;
            domicilio.Colonia = request.Colonia;
            domicilio.Municipio = request.Municipio;
            domicilio.Estado = request.Estado;
            domicilio.CP = request.CP;
            domicilio.Principal = request.Principal;
            return domicilio;
        }
    }
}
