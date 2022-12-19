using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.services.Dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
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
