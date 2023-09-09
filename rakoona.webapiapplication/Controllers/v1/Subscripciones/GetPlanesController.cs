using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clinicas
{
    [Route("api/subscripciones/planes")]
    [Authorize]
    [ApiController]
    public class GetPlanesController : ControllerBase
    {
        private readonly IPlanService _context;

        public GetPlanesController(IPlanService context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Subscripcion })]
        public async Task<ActionResult<ClinicaResponse>> Get()
        {

            var planes = await _context.GetPlanes();

            if (planes == null)
            {
                return NotFound();
            }

            return Ok(planes);
        }

    }
}
