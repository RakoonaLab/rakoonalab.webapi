using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Celular
{
    [Route("api/cliente/{clienteId}/celular")]
    [Authorize]
    [ApiController]
    public class GetCelularByClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetCelularByClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes", "Celular" })]
        public async Task<ActionResult<CelularResponse>> Get(string clienteId)
        {
            var cliente = _context.Clientes.Single(x => x.ExternalId == clienteId);

            var celular = _context.InformacionDeContacto.Where(x => x.PersonaRef == cliente.Id && x.ContactType == "Celular").FirstOrDefault();

            if (celular == null)
            {
                return NotFound();
            }

            return Ok(celular.MapToResponse());

        }

    }
}
