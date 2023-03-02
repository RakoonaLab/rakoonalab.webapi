using rakoona.models.dtos.Parameters;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IMascotaService
    {
        Task<MascotaResponse> CreateAsync(CreateMascotaRequest request, string clienteId);
        Task<MascotaResponse> GetAsync(string mascotaId);
        Task<List<MascotaResponse>> GetPorCliente(string clienteId);
        Task<PagedResponse<IList<MascotaResponse>>> GetPorClinica(string clinicaId, SearchMascotaParameters parameters, PaginationParameters pagination);
        Task<bool> DeleteAsync(string mascotaId);
        Task<bool> CreateImage(FileDetailsRequest request, string mascotaId);
    }
}
