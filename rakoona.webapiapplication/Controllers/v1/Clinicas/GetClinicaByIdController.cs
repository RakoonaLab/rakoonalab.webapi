using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clinicas
{
    [Route("api/clinica/{clinicaId}")]
    [Authorize]
    [ApiController]
    public class GetClinicaByIdController : ControllerBase
    {
        private readonly IClinicaService _context;

        public GetClinicaByIdController(IClinicaService context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Clinica })]
        public async Task<ActionResult<ClinicaResponse>> Get([FromRoute] string clinicaId)
        {

            var clinica = await _context.GetById(clinicaId);

            if (clinica == null)
            {
                return NotFound();
            }

            return Ok(clinica);
        }

    }
}
