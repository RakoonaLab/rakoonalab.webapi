using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Domicilio
{
    [Route("api/cliente/{clienteId}/domicilio")]
    [Authorize]
    [ApiController]
    public class GetDomicilioByClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetDomicilioByClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes", "Domicilio" })]
        public async Task<ActionResult<DomicilioResponse>> Get(string clienteId)
        {
            var cliente = _context.Clientes.Single(x => x.ExternalId == clienteId);

            var domicilio = _context.Domicilios.Where(x => x.PersonaRef == cliente.Id && x.Principal).FirstOrDefault();

            if (domicilio == null)
            {
                return NotFound();
            }

            return Ok(domicilio.MapToResponse());

        }

    }
}
