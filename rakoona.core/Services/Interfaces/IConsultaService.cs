using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<ConsultaResponse> CrearAsync(CreateConsultaRequest request, string mascotaId);
        Task<ConsultaResponse> GetConsultaById(string consultaId);
        Task<List<ConsultaResponse>> GetConsultasByMascota(string mascotaId);
        Task<List<ConsultaResponse>> GetConsultasByClinica(string clinicaId);
        Task<List<ConsultaResponse>> GetConsultaByCliente(string clienteId);
        Task<ConsultaResponse> Update(UpdateConsultaRequest request, string consultaId);
        Task<bool> DeleteAsync(string consultaId);
    }
}
