using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
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
            var clinica = request.CreateFromRequest(userId);

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
            var clinicas = await _context.Clinicas.Where(x => x.UserRef == userId).ToListAsync();

            return clinicas.Select(x => x.MapToResponse()).ToList();
        }
    }
}
