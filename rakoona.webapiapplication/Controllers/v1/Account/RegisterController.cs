using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(
            IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [SwaggerOperation(Tags = new[] { "Account" })]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (await _registerService.ValidateIfUserExist(model.Email))
                return BadRequest("El email ya esta dado de alta.");
            
            var response = await _registerService.Register(model);

            if (response.Status == "Error")
                return BadRequest(response.Errors.Select(x => x).ToJson());
            
            return Ok();
        }
    }
}
