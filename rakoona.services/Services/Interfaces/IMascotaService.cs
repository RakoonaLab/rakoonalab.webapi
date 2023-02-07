using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IMascotaService
    {
        Task<MascotaResponse> CreateAsync(CreateMascotaRequest request, string clienteId);
        Task<MascotaResponse> GetAsync(string mascotaId);
        Task<List<MascotaResponse>> GetPorCliente(string clienteId);
        Task<List<MascotaResponse>> GetPorClinica(string clinicaId);
        Task<bool> DeleteAsync(string mascotaId);
    }
}
