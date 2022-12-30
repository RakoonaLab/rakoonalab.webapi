using rakoona.models.dtos.Request.Domicilio;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IDomicilioService
    {
        Task<DomicilioResponse> CrearDomicilio(CreateDomicilioRequest request, string clienteId);
        DomicilioResponse? GetDomicilio(string domicilioId);
    }
}
