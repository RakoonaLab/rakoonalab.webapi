using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface ICitaService
    {
        Task<CitaResponse> Create(CreateCitaRequest request, string mascotaId);
        Task<List<CitaResponse>> GetCitasByClinica(string clinicaId);
    }
}
