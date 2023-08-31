using Microsoft.EntityFrameworkCore;
using rakoona.core.Context;
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

        public async Task<PlanResponse> GetFreePlan()
        {
            var plan = await _context.Planes
                .Include(x => x.Precios)
                .Where(x => x.Nombre == "Free").SingleAsync();

            return plan.MapToResponse();
        }
    }
}
