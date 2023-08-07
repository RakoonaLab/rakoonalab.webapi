using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class MedicoService : IMedicoService
    {
        private readonly ApplicationDbContext _context;

        public MedicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MedicoResponse> CrearAsync(CreateMedicoRequest request, string clinicaId)
        {
            if (_context.Medicos == null)
                throw new Exception("Validar _context.Medicos, es null");

            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");

            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            if (clinica == null)
            {
                throw new Exception("Validar _context.Clinicas, es null");
            }

            var medico = request.CreateFromRequest(clinica.Id);

            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();

            var response = medico.MapToResponse();
            return response;
        }

        public async Task<List<MedicoResponse>> GetMedicosByClinicaId(string clinicaId)
        {
            if (_context.ClinicasMedicos == null)
                throw new Exception("Validar _context.ClinicasMedicos, es null");

            var medicos = _context.ClinicasMedicos
                .Include(x => x.Medico)
                .ThenInclude(x => x.PersonaInfo)
                .Where(x => x.Clinica.ExternalId == clinicaId)
                .Select(x => x.Medico).ToList();

            return medicos.Select(x => x.MapToResponse()).ToList();
        }
    }
}
