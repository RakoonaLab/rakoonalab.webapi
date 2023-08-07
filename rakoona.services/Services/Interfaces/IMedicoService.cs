using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<MedicoResponse> CrearAsync(CreateMedicoRequest request, string clinicaId);
        Task<List<MedicoResponse>> GetMedicosByClinicaId(string clinicaId);
    }
}
