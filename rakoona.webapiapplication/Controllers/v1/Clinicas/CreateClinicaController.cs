using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clinicas
{
    [Route("api/clinica")]
    [Authorize]
    [ApiController]
    public class CreateClinicaController : ControllerBase
    {
        private readonly IClinicaService _clinicaService;
        private IUserInfoService _userInfo;
        public CreateClinicaController(
            IClinicaService context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _clinicaService = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Clinica })]
        public async Task<ActionResult<ClinicaResponse>> Post([FromBody] CreateClinicaRequest request)
        {
            var clinica = await _clinicaService.Create(request, _userInfo.UserId);
            if (clinica == null)
            {

            }
            return StatusCode(StatusCodes.Status201Created, clinica);
        }

    }
}
