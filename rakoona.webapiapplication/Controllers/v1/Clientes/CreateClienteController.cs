using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Clientes;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clientes
{
    [Route("api/clinica/{clinicaId}/cliente")]
    [Authorize]
    [ApiController]
    public class CreateClienteController : ControllerBase
    {
        private readonly IClienteService _context;
        private IUserInfoService _userInfo;
        public CreateClienteController(
            IClienteService context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<ClienteResponse>> Post([FromBody] CreateClienteRequest request, [FromRoute] string clinicaId)
        {

            var clinica = await _context.CreateCliente(request, clinicaId);
            if (clinica == null)
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status201Created, clinica);
        }

    }
}
