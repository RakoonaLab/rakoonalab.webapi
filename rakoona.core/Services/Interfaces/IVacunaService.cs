using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IVacunaService
    {
        Task<VacunaResponse> CrearAsync(CreateVacunaRequest request, string mascotaId);
        Task<List<VacunaResponse>> GetVacunasByMascota(string mascotaId);
        Task<List<VacunaResponse>> GetVacunasByClinica(string clinicaId);
        Task<List<VacunaResponse>> GetVacunasByCliente(string clienteId);
    }
}
