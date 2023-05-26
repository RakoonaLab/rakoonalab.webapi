using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface ICitaService
    {
        Task<CitaResponse> Create(CreateCitaRequest request, string mascotaId);
    }
}
