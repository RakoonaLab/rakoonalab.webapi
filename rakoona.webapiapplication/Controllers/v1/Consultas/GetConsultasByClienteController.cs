using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/cliente/{clienteId}/consultas")]
    [Authorize]
    [ApiController]
    public class GetConsultasByClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultasByClienteController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Clientes" })]
        public async Task<ActionResult<List<ConsultaResponse>>> Get([FromRoute] string clienteId)
        {
            var cliente = _context.Clientes.Single(x => x.ExternalId == clienteId);

            var consultas = _context.Consultas.Where(x => x.Mascota.DuenioRef == cliente.Id).ToList();

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
