using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Clientes;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Clientes
{
    [Route("api/cliente/{clienteId}")]
    [Authorize]
    [ApiController]
    public class UpdateClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;
        public UpdateClienteController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<ClienteResponse>> Put([FromBody] UpdateClienteRequest request, [FromRoute] string clienteId)
        {
            var cliente = _context.Clientes.Single(x => x.ExternalId == clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteUpdated = request.CreateFromRequest(cliente);

            _context.Clientes.Update(clienteUpdated);
            await _context.SaveChangesAsync();

            var response = clienteUpdated.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
