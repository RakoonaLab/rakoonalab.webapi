using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Parameters;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Entities.Models.Personas;
using rakoona.services.Services.Interfaces;
using System.Runtime.CompilerServices;

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

        public async Task<PagedResponse<IList<MascotaResponse>>> GetPorClinica(string clinicaId, SearchMascotaParameters parameters, PaginationParameters pagination)
        {
            if (_context.Clinicas == null)
                throw new Exception("Entity set 'ApplicationDbContext.Clinicas' is null.");
            if (_context.Mascotas == null)
                throw new Exception("Entity set 'ApplicationDbContext.Mascotas' is null.");
            if (_context.ClientesClinicas == null)
                throw new Exception("Entity set 'ApplicationDbContext.ClientesClinicas' is null.");

            var clinica = await _context.Clinicas.SingleAsync(x => x.ExternalId == clinicaId);

            //var mascotas = await _context.ClientesClinicas
            //    .Where(x => x.ClinicaId == clinica.Id)
            //    .SelectMany(c => c.Cliente.Mascotas)
            //    .Include(x => x.Duenio)
            //    .ToListAsync();

            //var query = _context.ClientesClinicas
            //    .Include(x => x.Cliente)
            //    .ThenInclude(x => x.Mascotas)
            //    .Where(x => x.Clinica.ExternalId == clinicaId);

            //var query = _context.Mascotas
            //    .Where(x => x.Duenio.ClienteClinicas.Exists(y=>y.ClinicaId == clinica.Id))
            //    .Include(x => x.Duenio)
            //    .AsQueryable();

            var query = _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .Include(x => x.Duenio).AsQueryable();

            


            if (pagination.Page > 1)
            {
                query = query.Skip(pagination.Page - 1 * pagination.PageSize);
            }
            query = query.Take(pagination.PageSize);

            if (!string.IsNullOrEmpty(parameters.Nombre))
            {
                var nombres = parameters.Nombre;
                query = query.Where(x => !string.IsNullOrEmpty(x.Nombre) && x.Nombre.Contains(nombres));
            }

            if (!string.IsNullOrEmpty(parameters.Especie))
            {
                var nombres = parameters.Especie;
                query = query.Where(x => !string.IsNullOrEmpty(x.Especie) && x.Especie.Contains(nombres));
            }

            if (!string.IsNullOrEmpty(parameters.Raza))
            {
                var nombres = parameters.Raza;
                query = query.Where(x => !string.IsNullOrEmpty(x.Raza) && x.Raza.Contains(nombres));
            }

            var mascotas = query.ToList();

            return new PagedResponse<IList<MascotaResponse>>(pagination.Page,
                pagination.PageSize,
                mascotas.Select(x => x.MapToResponse()).ToList(),
                mascotas.Count());
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

        public async Task<bool> CreateImage(FileDetailsRequest request, string mascotaId)
        {
            if (_context.ImagenesPorMascotas == null)
                throw new Exception("Validar _context.ImagenesPorMascotas, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");

            var mascota = await _context.Mascotas
                .SingleAsync(x => x.ExternalId == mascotaId);

            await _context.ImagenesPorMascotas.AddAsync(new Entities.Models.Pacientes.ImagenPorMascota()
            {
                FileData = request.FileData,
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                FileName = request.FileName,
                FileType = request.FileType,
                MascotaRef = mascota.Id,
                Principal = true

            });
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
