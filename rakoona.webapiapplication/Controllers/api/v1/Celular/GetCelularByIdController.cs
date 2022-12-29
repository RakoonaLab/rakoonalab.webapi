using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Celular
{
    [Route("api/celular/{celularId}")]
    [Authorize]
    [ApiController]
    public class GetCelularByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetCelularByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Celular" })]
        public async Task<ActionResult<CelularResponse>> Get(string celularId)
        {
            var celular = _context.InformacionDeContacto.Where(x => x.ExternalId == celularId && x.ContactType == "Celular").FirstOrDefault();

            if (celular == null)
            {
                return NotFound();
            }

            return Ok(celular.MapToResponse());

        }

    }
}
