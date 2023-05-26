using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clinicas
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class GetClinicasByUserController : ControllerBase
    {
        private readonly IClinicaService _context;
        private IUserInfoService _userInfo;

        public GetClinicasByUserController(
            IClinicaService context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Clinica })]
        public async Task<ActionResult<List<ClinicaResponse>>> Get()
        {
            var clinicas = await _context.GetByUser(_userInfo.UserId);

            if (clinicas == null)
                return NoContent();
            
            return Ok(clinicas);
        }

    }
}
