using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Celular
{
    [Route("api/celular/{celularId}")]
    [Authorize]
    [ApiController]
    public class GetCelularByIdController : ControllerBase
    {
        private readonly IInformacionDeContactoService _context;

        public GetCelularByIdController(IInformacionDeContactoService context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Celular" })]
        public async Task<ActionResult<CelularResponse>> Get(string celularId)
        {
            var celular = await _context.GetCelularById(celularId);

            if (celular == null)
            {
                return NotFound();
            }

            return Ok(celular);

        }

    }
}
