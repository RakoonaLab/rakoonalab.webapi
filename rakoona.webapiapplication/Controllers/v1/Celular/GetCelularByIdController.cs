using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
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
            var response = await _context.GetCelularById(celularId);
            if (response == null)
                return NoContent();
            return Ok(response);

        }

    }
}
