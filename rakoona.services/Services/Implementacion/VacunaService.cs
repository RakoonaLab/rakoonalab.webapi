using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class VacunaService : IVacunaService
    {
        private readonly ApplicationDbContext _context;

        public VacunaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VacunaResponse> CrearAsync(CreateVacunaRequest request, string mascotaId)
        {
            if (_context.Vacunas == null)
                throw new Exception("Validar _context.Vacunas, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");
            if (_context.Medicos == null)
                throw new Exception("Validar _context.Medicos, es null");

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            var medico = await _context.Medicos.SingleAsync(x => x.ExternalId == request.MedicoId);


            if (mascota == null)
                throw new Exception("Mascota no encontrada");

            var vacuna = request.CreateFromRequest(mascota.Id, medico.Id);

            await _context.Vacunas.AddAsync(vacuna);
            await _context.SaveChangesAsync();

            return vacuna.MapToResponse();
        }

        public async Task<List<VacunaResponse>> GetVacunasByMascota(string mascotaId)
        {
            if (_context.Vacunas == null)
                throw new Exception("Validar _context.Vacunas, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            if (mascota == null)
                throw new Exception("Mascota no encontrada");

            var vacunas = await _context.Vacunas.Where(x => x.MascotaRef == mascota.Id)

                .Include(m => m.Medico)
                .ThenInclude(x => x.PersonaInfo)
                .Include(c => c.Mascota)
                .ThenInclude(m => m.Duenio)
                .ToListAsync();

            return vacunas.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<List<VacunaResponse>> GetVacunasByCliente(string clienteId)
        {
            var vacunas = await _context.Clientes
                .Where(x => x.ExternalId == clienteId)
                .SelectMany(x => x.Mascotas)
                .SelectMany(v => v.Vacunas)

                .Include(m => m.Medico)
                .ThenInclude(x => x.PersonaInfo)
                .Include(c => c.Mascota)
                .ThenInclude(m => m.Duenio)
                .ToListAsync();

            return vacunas.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<List<VacunaResponse>> GetVacunasByClinica(string clinicaId)
        {
            if (_context.Vacunas == null)
                throw new Exception("Validar _context.Vacunas, es null");
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");

            var clinica = await _context.Clinicas.SingleAsync(x => x.ExternalId == clinicaId);

            var vacunas = await _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .SelectMany(v => v.Vacunas)

                .Include(m => m.Medico)
                .ThenInclude(x => x.PersonaInfo)
                .Include(c => c.Mascota)
                .ThenInclude(m => m.Duenio)
                .ToListAsync();

            return vacunas.Select(x => x.MapToResponse()).ToList();
        }
    }
}
