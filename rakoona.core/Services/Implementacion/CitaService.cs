using Microsoft.EntityFrameworkCore;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Context;
using rakoona.core.Entities.Mappers;
using rakoona.core.Services.Interfaces;

namespace rakoona.core.Services.Implementacion
{
    public class CitaService : ICitaService
    {
        private readonly ApplicationDbContext _context;

        public CitaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CitaResponse> Create(CreateCitaRequest request, string mascotaId)
        {
            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            if (mascota == null)
                throw new Exception("Mascota no encontrada");

            var cita = request.CreateFromRequest(mascota.Id);

            await _context.Citas.AddAsync(cita);
            await _context.SaveChangesAsync();

            return cita.MapToResponse();
        }

        public async Task<List<CitaResponse>> GetCitasByClinica(string clinicaId)
        {
            if (_context.Citas == null)
                throw new Exception("Validar _context.Citas, es null");
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");

            var clinica = await _context.Clinicas.SingleAsync(x => x.ExternalId == clinicaId);

            var citas = await _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .SelectMany(v => v.Citas)

                //.Include(m => m.Medico)
                //.ThenInclude(x => x.PersonaInfo)
                .Include(c => c.Mascota)
                .ThenInclude(m => m.Duenio)
                .ToListAsync();

            return citas.Select(x => x.MapToResponse()).ToList();
        }
    }
}
