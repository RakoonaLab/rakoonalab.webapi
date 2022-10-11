using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Consultas;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Consultas
{
    [Route("api/consultas")]
    [Authorize]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public CreateController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaResponse>> PostConsulta([FromBody] CreateConsultaRequest request)
        {
            if (_context.Clinicas == null)
                return Problem("Entity set 'ApplicationDbContext.Consultas'  is null.");

            var consulta = request.CreateFromRequest(_userInfo.UserId);

            _context.Consulta.Add(consulta);
            await _context.SaveChangesAsync();

            var response = consulta.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
