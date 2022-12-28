using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Mascota
{
    [Route("api/cliente/{clienteId}/mascota")]
    [Authorize]
    [ApiController]
    public class CreatePacienteConClienteIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;
        public CreatePacienteConClienteIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        public async Task<ActionResult<MascotaResponse>> Post([FromBody] CreatePacienteRequest request, [FromRoute] string clienteId)
        {
            if (_context.Mascotas == null)
                return Problem("Entity set 'ApplicationDbContext.Pacientes'  is null.");


            var cliente = _context.Clientes.Single(x => x.ExternalId == clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            var paciente = request.CreateFromRequest(cliente.Id);

            _context.Mascotas.Add(paciente);
            await _context.SaveChangesAsync();

            var response = paciente.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
