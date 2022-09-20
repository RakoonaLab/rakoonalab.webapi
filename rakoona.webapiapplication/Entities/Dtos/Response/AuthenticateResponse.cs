using rakoona.webapiapplication.Entities.Models.Seguridad;

namespace rakoona.webapiapplication.Entities.Dtos.Response
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {

            Token = token;
        }
    }
}
