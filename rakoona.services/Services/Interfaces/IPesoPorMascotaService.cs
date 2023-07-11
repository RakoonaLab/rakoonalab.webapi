using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IPesoPorMascotaService
    {
        Task<PesoPorMascotaResponse> CreateAsync(CreatePesoPorMascotaRequest request, string mascotaId);
    }
}
