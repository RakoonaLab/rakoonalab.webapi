using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class PesoPorMascotaService : IPesoPorMascotaService
    {
        public Task<PesoPorMascotaResponse> CreateAsync(CreatePesoPorMascotaRequest request, string mascotaId)
        {
            throw new NotImplementedException();
        }
    }
}
