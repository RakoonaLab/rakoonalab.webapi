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

        public async Task<VacunaResponse> CrearAsync(CreateVacunaRequest request, string cartillaId)
        {
            if (_context.Vacunas == null)
                throw new Exception("Validar _context.Vacunas, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");
            if (_context.Medicos == null)
                throw new Exception("Validar _context.Medicos, es null");

            var cartilla = await _context.Cartilla.SingleAsync(x => x.ExternalId == cartillaId);

            var medico = await _context.Medicos.SingleAsync(x => x.ExternalId == request.MedicoId);


            if (cartilla == null)
                throw new Exception("Mascota no encontrada");

            var vacuna = request.CreateFromRequest(cartilla.Id, medico.Id);

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

            var vacunas = await _context.Vacunas.Where(x => x.Cartilla.MascotaRef == mascota.Id)
                .Include(m => m.Medico)
                    .ThenInclude(x => x.PersonaInfo)
                .Include(c => c.Cartilla)
                    .ThenInclude(v => v.Mascota)
                        .ThenInclude(m => m.Duenio)
                .ToListAsync();

            return vacunas.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<List<VacunaResponse>> GetVacunasByCliente(string clienteId)
        {
            var cliente = await _context.Clientes
                .Where(x => x.ExternalId == clienteId)
                .FirstOrDefaultAsync();

            var mascotas = await _context.Mascotas
                .Where(x => x.DuenioRef == cliente.Id)
                .Include(m => m.Duenio)
                .Include(x => x.Cartilla)
                    .ThenInclude(x => x.PlanesDeVacunacion)
                        .ThenInclude(m => m.Medico)
                            .ThenInclude(x => x.PersonaInfo)
                .ToListAsync();

            var vacunas = mascotas.SelectMany(x => x.Cartilla.PlanesDeVacunacion);

            return vacunas.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<List<VacunaResponse>> GetVacunasByClinica(string clinicaId)
        {
            if (_context.Vacunas == null)
                throw new Exception("Validar _context.Vacunas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");

            var clinica = await _context.Clinicas.SingleAsync(x => x.ExternalId == clinicaId);

            var clienteClinica = await _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .Include(c => c.Cliente)
                    .ThenInclude(c => c.Mascotas)
                        .ThenInclude(c => c.Cartilla)
                            .ThenInclude(c => c.PlanesDeVacunacion)
                .Include(c => c.Cliente.Mascotas).ThenInclude(m => m.Duenio)
                .ToListAsync();

            var consultas = clienteClinica.SelectMany(x => x.Cliente.Mascotas.SelectMany(m => m.Cartilla.PlanesDeVacunacion)).ToList();

            return consultas.Select(x => x.MapToResponse()).ToList();
        }
    }
}
