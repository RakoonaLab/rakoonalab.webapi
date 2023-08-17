using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request;
using rakoona.dtos.Response;

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
