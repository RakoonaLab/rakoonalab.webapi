using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class MascotaService : IMascotaService
    {
        private readonly ApplicationDbContext _context;

        public MascotaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MascotaResponse> CreateAsync(CreateMascotaRequest request, string clienteId)
        {
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");
            if (_context.Clientes == null)
                throw new Exception("Validar _context.Clientes, es null");

            var cliente = await _context.Clientes.SingleAsync(x => x.ExternalId == clienteId);

            var paciente = request.CreateFromRequest(cliente.Id);

            await _context.Mascotas.AddAsync(paciente);
            await _context.SaveChangesAsync();

            return paciente.MapToResponse();
        }

        public async Task<MascotaResponse> GetAsync(string mascotaId)
        {
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");

            var mascota = await _context.Mascotas.Where(x => x.ExternalId == mascotaId)
                .Include(x => x.Duenio)
                .FirstOrDefaultAsync();

            if (mascota == null)
                throw new Exception("Validar _context.Mascotas, es null");

            return mascota.MapToResponse();
        }

        public async Task<List<MascotaResponse>> GetPorCliente(string clienteId)
        {
            if (_context.Clientes == null)
                throw new Exception("Entity set 'ApplicationDbContext.Clientes' is null.");
            if (_context.Mascotas == null)
                throw new Exception("Entity set 'ApplicationDbContext.Mascotas' is null.");


            var cliente = await _context.Clientes
                .SingleAsync(x => x.ExternalId == clienteId);

            if (cliente == null)
                throw new Exception("Validar _context.Mascotas, es null");

            var mascotas = await _context.Mascotas
                .Where(x => x.DuenioRef == cliente.Id)
                .Include(x => x.Duenio)
                .ToListAsync();

            return mascotas.Select(x => x.MapToResponse()).ToList();
        }

        public async Task<List<MascotaResponse>> GetPorClinica(string clinicaId)
        {
            if (_context.Clinicas == null)
                throw new Exception("Entity set 'ApplicationDbContext.Clinicas' is null.");
            if (_context.ClientesClinicas == null)
                throw new Exception("Entity set 'ApplicationDbContext.ClientesClinicas' is null.");

            var clinica = _context.Clinicas.First(x => x.ExternalId == clinicaId);

            var mascotas = await _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .Include(x => x.Duenio)
                .ToListAsync();

            return mascotas.Select(x => x.MapToResponse()).ToList();
        }

        public async Task<bool> DeleteAsync(string mascotaId)
        {
            if (_context.Mascotas == null)
                throw new Exception("Entity set 'ApplicationDbContext.Mascotas' is null.");

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            if (mascota == null)
                return false;

            _context.Mascotas.Remove(mascota);
            _context.SaveChanges();

            return true;
        }
    }
}
