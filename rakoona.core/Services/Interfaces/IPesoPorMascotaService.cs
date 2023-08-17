using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IPesoPorMascotaService
    {
        Task<PesoPorMascotaResponse> CreateAsync(CreatePesoPorMascotaRequest request, string mascotaId);
    }
}
