using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Models.Personas;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clientes
{
    [Route("api/clientes")]
    [Authorize]
    [ApiController]
    public class GetClienteByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetClienteByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

    }
}
