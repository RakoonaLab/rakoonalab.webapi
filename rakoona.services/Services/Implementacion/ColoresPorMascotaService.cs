using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class ColoresPorMascotaService : IColoresPorMascotaService
    {
        public Task<ColoresPorMascotaResponse> CreateAsync(CreateColoresPorMascotaRequest request, string mascotaId)
        {
            throw new NotImplementedException();
        }
    }
}
