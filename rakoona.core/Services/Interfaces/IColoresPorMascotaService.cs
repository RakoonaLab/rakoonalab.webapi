using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IColoresPorMascotaService
    {
        Task<ColoresPorMascotaResponse> CreateAsync(CreateColoresPorMascotaRequest request, string mascotaId);
    }
}
