using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Domicilio
{
    [Route("api/domicilio/{domicilioId}")]
    [Authorize]
    [ApiController]
    public class GetDomicilioByIdController : ControllerBase
    {
        private readonly IDomicilioService _domicilioService;

        public GetDomicilioByIdController(IDomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Domicilio" })]
        public async Task<ActionResult<DomicilioResponse>> Get(string domicilioId)
        {
            var domicilio = _domicilioService.GetDomicilio(domicilioId);

            if (domicilio == null)
                return NotFound();

            return Ok(domicilio);

        }

    }
}
