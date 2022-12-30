using Microsoft.EntityFrameworkCore;
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

        public async Task<DomicilioResponse> CrearDomicilioAsync(CreateDomicilioRequest request, string clienteId)
        {
            if (_context.Personas == null)
                throw new Exception("Validar _context.Personas, es null");
            if (_context.Domicilios == null)
                throw new Exception("Validar _context.Domicilios, es null");

            var cliente = await _context.Personas.SingleAsync(x => x.ExternalId == clienteId);
            var domicilio = request.CreateFromRequest(cliente.Id);

            await _context.Domicilios.AddAsync(domicilio);
            await _context.SaveChangesAsync();

            return domicilio.MapToResponse();
        }

        public async Task<DomicilioResponse?> GetDomicilioAsync(string domicilioId)
        {
            if (_context.Domicilios == null)
                throw new Exception("Validar _context.Domicilios, es null");

            var domicilio = await _context.Domicilios.SingleAsync(x => x.ExternalId == domicilioId && x.Principal);

            if (domicilio == null)
            {
                return null;
            }

            return domicilio.MapToResponse();
        }

        public async Task<DomicilioResponse?> GetDomicilioPrincipalByClienteAsync(string clienteId)
        {
            if (_context.Domicilios == null)
                throw new Exception("Validar _context.Domicilios, es null");
            if (_context.Clientes == null)
                throw new Exception("Validar _context.Clientes, es null");

            var cliente = await _context.Clientes.SingleAsync(x => x.ExternalId == clienteId);

            var domicilio = await _context.Domicilios.FirstOrDefaultAsync(x => x.PersonaRef == cliente.Id && x.Principal);

            if (domicilio == null)
                return null;

            return domicilio.MapToResponse();
        }

        public async Task<DomicilioResponse?> ActualizarAsync(UpdateDomicilioRequest request, string domicilioId)
        {
            if (_context.Domicilios == null)
                throw new Exception("Validar _context.Domicilios, es null");

            var domicilio = await _context.Domicilios.SingleAsync(x => x.ExternalId == domicilioId);

            if (domicilio == null)
                return null;

            var updated = request.UpdateFromRequest(domicilio);

            _context.Update(updated);
            await _context.SaveChangesAsync();

            return updated.MapToResponse();
        }
    }
}
