using rakoona.dtos.Request.InformacionDeContacto;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IInformacionDeContactoService
    {
        Task<CelularResponse> GetCelularByCliente(string clienteId);
        Task<CelularResponse?> ActualizarAsync(UpdateCelularRequest request, string celularId);
        Task<CelularResponse> GetCelularById(string celularId);
    }
}
