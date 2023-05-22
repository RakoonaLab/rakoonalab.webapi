using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clinicas
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class GetClientesController : ControllerBase
    {
        private readonly IClinicaService _context;
        private IUserInfoService _userInfo;

        public GetClientesController(
            IClinicaService context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clinica" })]
        public async Task<ActionResult<List<ClinicaResponse>>> Get()
        {
            var clinicas = _context.GetByUser(_userInfo.UserId);

            if (clinicas == null)
            {
                return NotFound();
            }

            return Ok(clinicas);
        }

    }
}
