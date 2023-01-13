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

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            if (mascota == null)
                throw new Exception("Mascota no encontrada");

            var vacuna = request.CreateFromRequest(mascota.Id);

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

            var vacunas = await _context.Vacunas.Where(x => x.Consulta.MascotaRef == mascota.Id)
                .Include(x => x.Consulta)
                .ToListAsync();

            return vacunas.Select(x => x.MapToResponse()).ToList();
        }
    }
}
