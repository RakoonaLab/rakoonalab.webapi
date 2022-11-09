using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Mascota
{
    [Route("api/clientes/{clienteId}/mascotas")]
    [Authorize]
    [ApiController]
    public class GetMascotasByClienteIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetMascotasByClienteIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<List<PacienteResponse>>> GetMascotasByClienteId([FromRoute] string clienteId)
        {
            if (_context.Mascotas == null)
            {
                return NotFound();
            }

            var cliente = _context.Clientes.FirstOrDefault(x => x.ExternalId == clienteId);

            var mascotas = _context.Mascotas.Where(x => x.DuenioRef == cliente.Id ).ToList();

            if (mascotas == null)
            {
                return NotFound();
            }

            return mascotas.Select(x => x.MapToResponse()).ToList();
        }

    }
}
