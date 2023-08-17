using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Account
{
    [Route("api/account/validate-token")]
    [Authorize]
    [ApiController]
    public class ValidateTokenController : ControllerBase
    {
        public ValidateTokenController()
        {

        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Account" })]
        public async Task<ActionResult<ClinicaResponse>> Get()
        {
            return Ok();
        }

    }
}
