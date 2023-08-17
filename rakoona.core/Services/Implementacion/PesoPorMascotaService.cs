using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;

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
