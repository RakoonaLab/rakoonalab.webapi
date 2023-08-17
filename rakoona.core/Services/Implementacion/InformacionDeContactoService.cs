using Microsoft.EntityFrameworkCore;
using rakoona.dtos.Request.InformacionDeContacto;
using rakoona.dtos.Response;
using rakoona.core.Context;
using rakoona.core.Entities.Mappers;
using rakoona.core.Services.Interfaces;

namespace rakoona.core.Services.Implementacion
{
    public class InformacionDeContactoService : IInformacionDeContactoService
    {
        private readonly ApplicationDbContext _context;

        public InformacionDeContactoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CelularResponse> GetCelularByCliente(string clienteId)
        {
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");
            if (_context.InformacionDeContacto == null)
                throw new Exception("Validar _context.InformacionDeContacto, es null");
            if (_context.Clientes == null)
                throw new Exception("Validar _context.Clientes, es null");

            var cliente = await _context.Clientes.SingleAsync(x => x.ExternalId == clienteId);

            var celular = await _context.InformacionDeContacto.Where(x => x.PersonaRef == cliente.Id && x.ContactType == "Celular").FirstOrDefaultAsync();

            return celular.MapToResponse();

        }

        public async Task<CelularResponse?> ActualizarAsync(UpdateCelularRequest request, string celularId)
        {
            if (_context.InformacionDeContacto == null)
                throw new Exception("Validar _context.InformacionDeContacto, es null");

            var celular = await _context.InformacionDeContacto.SingleAsync(x => x.ExternalId == celularId);

            if (celular == null)
                return null;


            var updated = request.UpdateFromRequest(celular);

            _context.Update(updated);
            await _context.SaveChangesAsync();

            return updated.MapToResponse();
        }
        public async Task<CelularResponse> GetCelularById(string celularId)
        {
            var celular = await _context.InformacionDeContacto.Where(x => x.ExternalId == celularId && x.ContactType == "Celular").FirstOrDefaultAsync();

            return celular.MapToResponse();

        }
    }
}
