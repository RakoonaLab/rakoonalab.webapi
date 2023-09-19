using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Account
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(
            IAccountService accountService,
            ILogger<LoginController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        
        [SwaggerOperation(Tags = new[] { "Account" })]
        [HttpPost]
        [ProducesResponseType(typeof(TokenResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest request)
        {
            _logger.LogInformation("Login...");
            var token = await _accountService.Login(request);
            if (token != null)
                return Ok(token);
            
            return Unauthorized();
        }
    }
}
