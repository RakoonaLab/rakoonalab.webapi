using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.services.Dtos.Response;
using rakoona.services.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Mascota
{
    [Route("api/clinica/{clinicaId}/mascotas")]
    [Authorize]
    [ApiController]
    public class GetMascotasByClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetMascotasByClinicaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Mascotas", "Clinica" })]
        public async Task<ActionResult<List<MascotaResponse>>> Get([FromRoute] string clinicaId)
        {
            if (_context.Mascotas == null)
            {
                return NotFound();
            }

            var clinica = _context.Clinicas.First(x => x.ExternalId == clinicaId);

            var mascotas = _context.ClientesClinicas.Where(x => x.ClinicaId == clinica.Id).SelectMany(c => c.Cliente.Mascotas).ToList();

            if (mascotas == null)
            {
                return NotFound();
            }

            return Ok(mascotas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
