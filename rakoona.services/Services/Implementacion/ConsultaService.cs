using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class ConsultaService : IConsultaService
    {
        private readonly ApplicationDbContext _context;

        public ConsultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ConsultaResponse> CrearAsync(CreateConsultaRequest request, string mascotaId)
        {
            if (_context.Consultas == null)
                throw new Exception("Validar _context.Consultas, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            if (mascota == null)
                throw new Exception("Mascota no encontrada");

            var consulta = request.CreateFromRequest(mascota.Id);

            await _context.Consultas.AddAsync(consulta);
            await _context.SaveChangesAsync();

            return consulta.MapToResponse();
        }

    }
}
