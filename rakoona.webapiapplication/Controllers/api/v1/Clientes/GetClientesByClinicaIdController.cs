using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clientes
{
    [Route("api/clientes/clinica/{clinicaId}")]
    [Authorize]
    [ApiController]
    public class GetClientesByClinicaIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetClientesByClinicaIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<List<ClienteResponse>>> GetClientesByClinicaId([FromRoute] string clinicaId)
        {
            if (_context.ClientesClinicas == null)
            {
                return NotFound();
            }
            var clientes = _context.ClientesClinicas.Where(x => x.Clinica.UserRef == _userInfo.UserId && x.Clinica.ExternalId == clinicaId).Select(x => x.Cliente).ToList();

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes.Select(x => x.MapToResponse()).ToList();
        }

    }
}
