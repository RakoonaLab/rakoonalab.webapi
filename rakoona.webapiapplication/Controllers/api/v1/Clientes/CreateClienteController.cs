using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Clientes
{
    [Route("api/clinica/{clinicaId}/cliente")]
    [Authorize]
    [ApiController]
    public class CreateClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;
        public CreateClienteController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<ClienteResponse>> Post([FromBody] CreateClienteRequest request, [FromRoute] string clinicaId)
        {
            if (_context.Clientes == null)
                return Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");

            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            if (clinica == null)
            {
                return NotFound();
            }

            var cliente = request.CreateFromRequest(clinica.Id);

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var response = cliente.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
