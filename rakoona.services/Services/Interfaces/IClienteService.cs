using rakoona.models.dtos.Parameters;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IClienteService
    {
        Task<PagedResponse<List<ClienteResponse>>> GetClientesByClinica(string clinicaId,
                                                        SearchClienteParameters parameters,
                                                        PaginationParameters pagination);
    }
}
