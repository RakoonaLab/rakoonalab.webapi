using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<ConsultaResponse> CrearAsync(CreateConsultaRequest request, string mascotaId);
    }
}
