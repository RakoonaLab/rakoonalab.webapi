using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas.Clasificacion
{
    [Route("api/clasificacion/familias")]
    [ApiController]
    public class GetFamiliasController : ControllerBase
    {
        private readonly IClasificacionService _clasificacionService;
        public GetFamiliasController(
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
            var respuesta = await _clasificacionService.GetFamilias();

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
