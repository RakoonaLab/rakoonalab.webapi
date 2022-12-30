using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Domicilio
{
    [Route("api/domicilio/{domicilioId}")]
    [Authorize]
    [ApiController]
    public class GetDomicilioByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetDomicilioByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Domicilio" })]
        public async Task<ActionResult<DomicilioResponse>> Get(string domicilioId)
        {
            var domicilio = _context.Domicilios.Where(x => x.ExternalId == domicilioId && x.Principal).FirstOrDefault();

            if (domicilio == null)
            {
                return NotFound();
            }

            return Ok(domicilio.MapToResponse());

        }

    }
}
