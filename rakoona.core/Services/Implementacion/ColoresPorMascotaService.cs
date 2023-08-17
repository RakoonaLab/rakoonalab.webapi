using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;

namespace rakoona.core.Services.Implementacion
{
    public class ColoresPorMascotaService : IColoresPorMascotaService
    {
        public Task<ColoresPorMascotaResponse> CreateAsync(CreateColoresPorMascotaRequest request, string mascotaId)
        {
            throw new NotImplementedException();
        }
    }
}
