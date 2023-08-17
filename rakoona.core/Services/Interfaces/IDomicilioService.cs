using rakoona.dtos.Request.Domicilio;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IDomicilioService
    {
        Task<DomicilioResponse> CrearByClienteAsync(CreateDomicilioRequest request, string clienteId);
        Task<DomicilioResponse> CrearByMascotaAsync(CreateDomicilioRequest request, string mascotaId);
        Task<DomicilioResponse?> GetDomicilioAsync(string domicilioId);
        Task<DomicilioResponse?> GetDomicilioPrincipalByClienteAsync(string clienteId);
        Task<DomicilioResponse?> GetDomicilioPrincipalByMascotaAsync(string mascotaId);
        Task<DomicilioResponse?> ActualizarAsync(UpdateDomicilioRequest request, string domicilioId);
    }
}
