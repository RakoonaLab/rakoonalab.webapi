using rakoona.models.dtos.Parameters;
using rakoona.models.dtos.Response;

namespace rakoona.services.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteResponse>> GetClientesByClinica(string clinicaId,
                                                        SearchClienteParameters parameters,
                                                        PaginationParameters pagination);
    }
}
