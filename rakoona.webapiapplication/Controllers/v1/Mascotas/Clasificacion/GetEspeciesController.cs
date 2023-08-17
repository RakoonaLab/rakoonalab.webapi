using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas.Clasificacion
{
    [Route("api/clasificacion/especies")]
    [ApiController]
    public class GetEspeciesController : ControllerBase
    {
        private readonly IClasificacionService _clasificacionService;
        public GetEspeciesController(
            IClasificacionService clasificacionService)
        {
            _clasificacionService = clasificacionService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Clasificacion })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<FamiliaResponse>> GetAsync()
        {
            var respuesta = await _clasificacionService.GetEspecies();

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
