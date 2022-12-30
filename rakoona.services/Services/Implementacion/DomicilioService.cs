using rakoona.models.dtos.Request.Domicilio;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class DomicilioService : IDomicilioService
    {
        private readonly ApplicationDbContext _context;

        public DomicilioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DomicilioResponse> CrearDomicilio(CreateDomicilioRequest request, string clienteId)
        {
            var cliente = _context.Personas.First(x => x.ExternalId == clienteId);
            var domicilio = request.CreateFromRequest(cliente.Id);

            _context.Domicilios.Add(domicilio);
            await _context.SaveChangesAsync();

            return domicilio.MapToResponse();
        }

        public DomicilioResponse? GetDomicilio(string domicilioId)
        {
            var domicilio = _context.Domicilios.Single(x => x.ExternalId == domicilioId && x.Principal);

            if (domicilio == null)
            {
                return null;
            }

            return domicilio.MapToResponse();

        }
    }
}
