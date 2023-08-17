using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.models.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas.Clasificacion
{
    [Route("api/clasificacion/familia/{familiaId}/generos")]
    [ApiController]
    public class GetGeneroPorFamiliaController : ControllerBase
    {
        private readonly IClasificacionService _clasificacionService;
        public GetGeneroPorFamiliaController(
            IClasificacionService clasificacionService)
        {
            _clasificacionService = clasificacionService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Clasificacion })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<FamiliaResponse>> GetAsync([FromRoute] string familiaId)
        {
            var respuesta = await _clasificacionService.GetGenerosPorFamilia(familiaId);

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
