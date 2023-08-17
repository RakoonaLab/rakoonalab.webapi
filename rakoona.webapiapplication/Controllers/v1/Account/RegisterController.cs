using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using rakoona.core.Entities.Models;
using rakoona.core.Entities.Models.Seguridad;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Account
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
                UserName = model.Email,
                Organizacion = new Organizacion()
                {
                    ExternalId = Guid.NewGuid().ToString()
                }

            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = result.Errors.Select(x => x.Description).ToJson() });


            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

    }
}
