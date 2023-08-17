using Microsoft.EntityFrameworkCore;
using rakoona.dtos.Request.Domicilio;
using rakoona.dtos.Response;
using rakoona.core.Context;
using rakoona.core.Entities.Mappers;
using rakoona.core.Services.Interfaces;

namespace rakoona.core.Services.Implementacion
{
    public class DomicilioService : IDomicilioService
    {
        private readonly ApplicationDbContext _context;

        public DomicilioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DomicilioResponse> CrearByClienteAsync(CreateDomicilioRequest request, string clienteId)
        {
            if (_context.Personas == null)
                throw new Exception("Validar _context.Personas, es null");
            if (_context.Domicilios == null)
                throw new Exception("Validar _context.Domicilios, es null");

            var cliente = await _context.Personas.SingleAsync(x => x.ExternalId == clienteId);
            if (request.Principal)
            {
                var domicilioPrincipal = await _context.Domicilios.FirstOrDefaultAsync(x => x.PersonaRef == cliente.Id && x.Principal);
                if (domicilioPrincipal != null)
                {
                    domicilioPrincipal.Principal = false;
                    _context.Domicilios.Update(domicilioPrincipal);
                }
            }

            var domicilio = request.CreateFromRequest(cliente.Id);

            await _context.Domicilios.AddAsync(domicilio);
            await _context.SaveChangesAsync();

            return domicilio.MapToResponse();
        }

        public async Task<DomicilioResponse> CrearByMascotaAsync(CreateDomicilioRequest request, string mascotaId)
        {
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");
            if (_context.Domicilios == null)
                throw new Exception("Validar _context.Domicilios, es null");

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);
            if (request.Principal)
            {
                var domicilioPrincipal = await _context.Domicilios.FirstOrDefaultAsync(x => x.PersonaRef == mascota.DuenioRef && x.Principal);
                if (domicilioPrincipal != null)
                {
                    domicilioPrincipal.Principal = false;
                    _context.Domicilios.Update(domicilioPrincipal);
                }
            }

            var domicilio = request.CreateFromRequest(mascota.DuenioRef);

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

        public async Task<DomicilioResponse?> GetDomicilioPrincipalByMascotaAsync(string mascotaId)
        {
            if (_context.Domicilios == null)
                throw new Exception("Validar _context.Domicilios, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            var domicilio = await _context.Domicilios.FirstOrDefaultAsync(x => x.PersonaRef == mascota.DuenioRef && x.Principal);

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

            if (request.Principal)
            {
                var domicilioPrincipal = await _context.Domicilios.FirstOrDefaultAsync(x => x.Principal);
                if (domicilioPrincipal != null && (domicilio.Id != domicilioPrincipal.Id))
                {
                    domicilioPrincipal.Principal = false;
                    _context.Domicilios.Update(domicilioPrincipal);
                }
            }

            var updated = request.UpdateFromRequest(domicilio);

            _context.Update(updated);
            await _context.SaveChangesAsync();

            return updated.MapToResponse();
        }
    }
}
