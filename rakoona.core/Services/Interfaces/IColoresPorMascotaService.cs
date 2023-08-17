using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IColoresPorMascotaService
    {
        Task<ColoresPorMascotaResponse> CreateAsync(CreateColoresPorMascotaRequest request, string mascotaId);
    }
}
