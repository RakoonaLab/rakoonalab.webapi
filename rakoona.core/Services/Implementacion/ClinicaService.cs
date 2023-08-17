using Microsoft.EntityFrameworkCore;
using rakoona.core.Context;
using rakoona.core.Entities.Mappers;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Implementacion
{
    public class ClinicaService : IClinicaService
    {
        private ApplicationDbContext _context;

        public ClinicaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClinicaResponse> Create(CreateClinicaRequest request, string userId)
        {
            var organizacion = await _context.Organizacion.Where(x => x.UserRef == userId).FirstOrDefaultAsync();

            var clinica = request.CreateFromRequest(organizacion.Id);

            await _context.Clinicas.AddAsync(clinica);
            await _context.SaveChangesAsync();

            return clinica.MapToResponse();
        }

        public async Task<ClinicaResponse> GetById(string clinicaId)
        {
            var clinica = await _context.Clinicas.SingleAsync(x => x.ExternalId == clinicaId);

            return clinica.MapToResponse();
        }
        public async Task<List<ClinicaResponse>> GetByUser(string userId)
        {
            var clinicas = await _context.Clinicas.Where(x => x.Organizacion.UserRef == userId).ToListAsync();

            return clinicas.Select(x => x.MapToResponse()).ToList();
        }
    }
}
