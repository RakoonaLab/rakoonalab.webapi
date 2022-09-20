using System.ComponentModel.DataAnnotations;

namespace rakoona.webapiapplication.Entities.Dtos.Request
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
