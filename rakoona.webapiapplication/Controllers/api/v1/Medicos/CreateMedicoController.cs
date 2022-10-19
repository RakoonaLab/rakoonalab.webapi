using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Medicos
{
    [Route("api/medico/clinica/{clinicaId}")]
    [Authorize]
    [ApiController]
    public class CreateMedicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;
        public CreateMedicoController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Medicos" })]
        public async Task<ActionResult<MedicoResponse>> Post([FromBody] CreateMedicoRequest request, [FromRoute] string clinicaId)
        {
            if (_context.Medicos == null)
                return Problem("Entity set 'ApplicationDbContext.Medicos'  is null.");

            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            if (clinica == null)
            {
                return NotFound();
            }

            var medico = request.CreateFromRequest(clinica.Id);

            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();

            var response = medico.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
