using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas.Clasificacion
{
    [Route("api/clasificacion/especie/{especieId}/razas")]
    [ApiController]
    public class GetRazasPorEspecieController : ControllerBase
    {
        private readonly IClasificacionService _clasificacionService;
        public GetRazasPorEspecieController(
            IClasificacionService clasificacionService)
        {
            _clasificacionService = clasificacionService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Clasificacion })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RazaResponse>> GetAsync([FromRoute] string especieId)
        {
            var respuesta = await _clasificacionService.GetRazasPorEspecie(especieId);

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
