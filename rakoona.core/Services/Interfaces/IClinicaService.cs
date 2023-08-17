using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IClinicaService
    {
        Task<ClinicaResponse> Create(CreateClinicaRequest request, string userId);
        Task<ClinicaResponse> GetById(string clinicaId);
        Task<List<ClinicaResponse>> GetByUser(string userId);
    }
}
