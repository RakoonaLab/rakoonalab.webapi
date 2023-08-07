using rakoona.models.dtos.Request.InformacionDeContacto;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IInformacionDeContactoService
    {
        Task<CelularResponse> GetCelularByCliente(string clienteId);
        Task<CelularResponse?> ActualizarAsync(UpdateCelularRequest request, string celularId);
        Task<CelularResponse> GetCelularById(string celularId);
    }
}
