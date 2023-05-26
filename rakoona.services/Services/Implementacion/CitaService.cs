using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class CitaService : ICitaService
    {
        public Task<CitaResponse> Create(CreateCitaRequest request, string mascotaId)
        {
            throw new NotImplementedException();
        }
    }
}
