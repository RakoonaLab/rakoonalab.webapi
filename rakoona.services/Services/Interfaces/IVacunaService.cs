using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IVacunaService
    {
        Task<VacunaResponse> CrearAsync(CreateVacunaRequest request, string mascotaId);
        Task<List<VacunaResponse>> GetVacunasByMascota(string mascotaId);
        Task<List<VacunaResponse>> GetVacunasByClinica(string clinicaId);
    }
}
