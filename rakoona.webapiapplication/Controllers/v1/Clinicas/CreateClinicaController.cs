using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clinicas
{
    [Route("api/clinica")]
    [Authorize]
    [ApiController]
    public class CreateClinicaController : ControllerBase
    {
        private readonly IClinicaService _context;
        private IUserInfoService _userInfo;
        public CreateClinicaController(
            IClinicaService context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Clinica" })]
        public async Task<ActionResult<ClinicaResponse>> Post([FromBody] CreateClinicaRequest request)
        {
            var clinica = await _context.Create(request, _userInfo.UserId);
            if (clinica == null)
            {

            }
            return StatusCode(StatusCodes.Status201Created, clinica);
        }

    }
}
