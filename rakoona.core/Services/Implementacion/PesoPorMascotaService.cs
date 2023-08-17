using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Implementacion
{
    public class PesoPorMascotaService : IPesoPorMascotaService
    {
        public Task<PesoPorMascotaResponse> CreateAsync(CreatePesoPorMascotaRequest request, string mascotaId)
        {
            throw new NotImplementedException();
        }
    }
}
