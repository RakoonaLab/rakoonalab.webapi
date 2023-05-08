using System.IdentityModel.Tokens.Jwt;

namespace rakoona.webapi.Services
{
    public interface IUserInfoService
    {
        public string UserId { get; }
    }

    public class UserInfoService : IUserInfoService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public string UserId { get; }


        public UserInfoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            var authorization = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];

            var token = authorization.ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(token);

            UserId = decodedValue.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.NameId).Value;
        }


    }


}
