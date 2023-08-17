﻿using rakoona.dtos.Parameters;
using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IMascotaService
    {
        Task<MascotaResponse> CreateAsync(CreateMascotaRequest request, string clienteId);
        Task<MascotaResponse> GetAsync(string mascotaId);
        Task<List<MascotaResponse>> GetPorCliente(string clienteId);
        Task<PagedResponse<IList<MascotaResponse>>> GetPorClinica(string clinicaId, SearchMascotaParameters parameters, PaginationParameters pagination);
        Task<int> GetContadorDeMascotasPorClinica(string clinicaId);
        Task<bool> DeleteAsync(string mascotaId);
        Task<bool> CreateImage(FileDetailsRequest request, string mascotaId);
    }
}
