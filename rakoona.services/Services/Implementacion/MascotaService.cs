using rakoona.services.Context;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class MascotaService : IMascotaService
    {
        private readonly ApplicationDbContext _context;

        public MascotaService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
