using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clientes
{
    [Route("api/cliente/{clienteId}")]
    [Authorize]
    [ApiController]
    public class GetClienteByIdController : ControllerBase
    {
        private readonly IClienteService _context;

        public GetClienteByIdController(IClienteService context)
        {
            _context = context;
        }

        // GET: api/Clientes/5
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<ClienteResponse>> Get(string clienteId)
        {
            var cliente = await _context.GetById(clienteId);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

    }
}
