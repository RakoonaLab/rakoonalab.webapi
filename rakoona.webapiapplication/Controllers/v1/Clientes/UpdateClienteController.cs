using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request.Clientes;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clientes
{
    [Route("api/cliente/{clienteId}")]
    [Authorize]
    [ApiController]
    public class UpdateClienteController : ControllerBase
    {
        private readonly IClienteService _context;
        public UpdateClienteController(
            IClienteService context)
        {
            _context = context;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<ClienteResponse>> Put([FromBody] UpdateClienteRequest request, [FromRoute] string clienteId)
        {
            var cliente = await _context.Update(request, clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status201Created, cliente);
        }

    }
}
