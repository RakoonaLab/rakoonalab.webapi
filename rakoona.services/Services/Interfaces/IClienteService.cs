using rakoona.models.dtos.Parameters;
using rakoona.models.dtos.Request.Clientes;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponse> CreateCliente(CreateClienteRequest request, string clinicaId); 
        Task<PagedResponse<List<ClienteResponse>>> GetClientesByClinica(string clinicaId,
                                                        SearchClienteParameters parameters,
                                                        PaginationParameters pagination);
        Task<int> GetContadorClientesByClinica(string clinicaId);
        Task<ClienteResponse> GetById(string clienteId);
        Task<ClienteResponse> Update(UpdateClienteRequest request, string clienteId);
    }
}
