using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<MedicoResponse> CrearAsync(CreateMedicoRequest request, string clinicaId);
        Task<List<MedicoResponse>> GetMedicosByClinicaId(string clinicaId);
    }
}
