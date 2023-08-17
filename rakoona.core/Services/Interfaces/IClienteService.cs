using rakoona.dtos.Parameters;
using rakoona.dtos.Request.Clientes;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
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
