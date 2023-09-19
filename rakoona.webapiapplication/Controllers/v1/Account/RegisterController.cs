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
        private readonly IAccountService _accountService;

        public RegisterController(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        [SwaggerOperation(Tags = new[] { "Account" })]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (string.IsNullOrEmpty( model.Email))
                return BadRequest(ModelState);
            
            if (await _accountService.ValidateIfUserExist(model.Email))
                return BadRequest("El email ya esta dado de alta.");
            
            var response = await _accountService.Register(model);

            if (response.Status == "Error")
                return BadRequest(response.Errors.Select(x => x).ToJson());
            
            return Ok();
        }
    }
}
