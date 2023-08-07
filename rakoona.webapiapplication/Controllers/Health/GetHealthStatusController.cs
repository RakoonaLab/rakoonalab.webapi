using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.Health
{
    [Route("api/health")]
    [Authorize]
    [ApiController]
    public class GetHealthStatusController : ControllerBase
    {
        public GetHealthStatusController()
        {

        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] {
            "Health"
        })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public ActionResult Get()
        {


            return Ok();
        }

    }
}
