using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/consulta/{consultaId}")]
    [Authorize]
    [ApiController]
    public class DeleteConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public DeleteConsultaController(
            IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaResponse>> Delete([FromRoute] string consultaId)
        {
            var delete = await _consultaService.DeleteAsync(consultaId);

            if (delete)
            {
                return StatusCode(StatusCodes.Status200OK);
            }

            return Problem();
        }

    }
}
