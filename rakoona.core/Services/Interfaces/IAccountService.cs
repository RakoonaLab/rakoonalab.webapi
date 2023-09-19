using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> ValidateIfUserExist(string email);
        Task<Response> Register(RegisterRequest model);
        Task<TokenResponse> Login(AuthenticateRequest model);
    }
}
