using Microsoft.EntityFrameworkCore;
using rakoona.core.Context;
using rakoona.core.Entities.Mappers;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Implementacion
{
    public class PlanService : IPlanService
    {
        private readonly ApplicationDbContext _context;

        public PlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlanResponse>> GetPlanes()
        {
            var planes = await _context.Planes.ToListAsync();

            return planes.Select(x => x.MapToResponse());
        }
    }
}
