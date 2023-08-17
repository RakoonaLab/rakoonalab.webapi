using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IClasificacionService
    {
        Task<List<FamiliaResponse>> GetFamilias();
        Task<List<EspecieResponse>> GetEspecies();
        Task<List<GeneroAnimalResponse>> GetGenerosPorFamilia(string familiaId);
        Task<List<RazaResponse>> GetRazasPorEspecie(string especieId);
        Task<List<EspecieResponse>> GetEspeciesPorGenero(string generoId);
    }
}
