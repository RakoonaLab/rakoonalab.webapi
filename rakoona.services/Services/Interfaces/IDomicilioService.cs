using rakoona.models.dtos.Request.Domicilio;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IDomicilioService
    {
        Task<DomicilioResponse> CrearDomicilioAsync(CreateDomicilioRequest request, string clienteId);
        Task<DomicilioResponse?> GetDomicilioAsync(string domicilioId);
        Task<DomicilioResponse?> GetDomicilioPrincipalByClienteAsync(string clienteId);
        Task<DomicilioResponse?> ActualizarAsync(UpdateDomicilioRequest request, string domicilioId);
    }
}
