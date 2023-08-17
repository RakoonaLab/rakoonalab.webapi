using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/consulta/{consultaId}")]
    [Authorize]
    [ApiController]
    public class GetConsultaByIdController : ControllerBase
    {
        private readonly IConsultaService _context;
        private IUserInfoService _userInfo;

        public GetConsultaByIdController(
            IConsultaService context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaResponse>> Get([FromRoute] string consultaId)
        {

            var consulta = await _context.GetConsultaById(consultaId);

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta);
        }

    }
}
