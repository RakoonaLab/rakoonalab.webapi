using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.services.Entities.Models.Seguridad;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Authenticate
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public RegisterController(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [SwaggerOperation(Tags = new[] { "Account" })]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) 
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = result.Errors.Select(x=> x.Description).ToJson() });
            
                
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

    }
}
