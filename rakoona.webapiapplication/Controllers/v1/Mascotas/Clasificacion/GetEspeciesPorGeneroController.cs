using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas.Clasificacion
{
    [Route("api/clasificacion/genero/{generoId}/especies")]
    [ApiController]
    public class GetEspeciesPorGeneroController : ControllerBase
    {
        private readonly IClasificacionService _clasificacionService;
        public GetEspeciesPorGeneroController(
            IClasificacionService clasificacionService)
        {
            _clasificacionService = clasificacionService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Clasificacion })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EspecieResponse>> GetAsync([FromRoute] string generoId)
        {
            var respuesta = await _clasificacionService.GetEspeciesPorGenero(generoId);

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
