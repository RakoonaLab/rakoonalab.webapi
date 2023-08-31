using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<bool> ValidateIfUserExist(string email);
        Task<Response> Register(RegisterRequest model);
    }
}
