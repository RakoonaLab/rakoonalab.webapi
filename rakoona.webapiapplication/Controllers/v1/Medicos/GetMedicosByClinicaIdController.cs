using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Medicos
{
    [Route("api/clinica/{clinicaId}/medicos")]
    [Authorize]
    [ApiController]
    public class GetMedicosByClinicaIdController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public GetMedicosByClinicaIdController(
            IMedicoService medicoService
            )
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Medicos", "Clinica" })]
        public async Task<ActionResult<List<MedicoResponse>>> Get([FromRoute] string clinicaId)
        {
            var response = await _medicoService.GetMedicosByClinicaId(clinicaId);
            return StatusCode(StatusCodes.Status200OK, response);
        }

    }
}
