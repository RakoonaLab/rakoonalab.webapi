using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request.InformacionDeContacto;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Celular
{
    [Route("api/celular/{celularId}")]
    [Authorize]
    [ApiController]
    public class ÚpdateCelularController : ControllerBase
    {
        private readonly IInformacionDeContactoService _context;

        public ÚpdateCelularController(
            IInformacionDeContactoService context)
        {
            _context = context;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Celular" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CelularResponse>> Put([FromBody] UpdateCelularRequest request, [FromRoute] string celularId)
        {

            var celular = await _context.ActualizarAsync(request, celularId);
            if (celular == null)
                return StatusCode(StatusCodes.Status304NotModified, "contacto no encontrad0");

            return StatusCode(StatusCodes.Status200OK, celular);
        }

    }
}
