using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Medicos
{
    [Route("api/medicos/clinica/{clinicaId}")]
    [Authorize]
    [ApiController]
    public class GetMedicosPorClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetMedicosPorClinicaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Medicos" })]
        public async Task<ActionResult<List<MedicoResponse>>> GetMedicosPorClinica([FromRoute] string clinicaId)
        {
            if (_context.Clinicas == null)
            {
                return NotFound();
            }
            var medicos = _context.ClinicasMedicos.Where(x => x.Clinica.UserRef == _userInfo.UserId && x.Clinica.ExternalId == clinicaId).Select(x => x.Medico).ToList();

            if (medicos == null)
            {
                return NotFound();
            }

            return medicos.Select(x => x.MapToResponse()).ToList();
        }

    }
}
