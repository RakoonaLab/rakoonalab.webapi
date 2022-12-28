using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using rakoona.services.Entities.Mappers;

namespace rakoona.webapiapplication.Controllers.api.v1.Mascota
{
    [Route("api/clientes/{clienteId}/mascotas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByMascotaIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetVacunasByMascotaIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        public async Task<ActionResult<List<MascotaResponse>>> Get([FromRoute] string clienteId)
        {
            if (_context.Mascotas == null)
            {
                return NotFound();
            }

            var cliente = _context.Clientes.FirstOrDefault(x => x.ExternalId == clienteId);

            var mascotas = _context.Mascotas.Where(x => x.DuenioRef == cliente.Id)
                .Include(x => x.Consultas).ToList();

            if (mascotas == null)
            {
                return NotFound();
            }

            return mascotas.Select(x => x.MapToResponse()).ToList();
        }

    }
}
