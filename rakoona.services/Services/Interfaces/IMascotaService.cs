using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IMascotaService
    {
        Task<ApplicationResponse> CreateAsync(CreatePacienteRequest request, string clienteId);
    }
}
