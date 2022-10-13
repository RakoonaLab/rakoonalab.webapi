using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Clientes
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class CreateClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;
        public CreateClienteController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<ClienteResponse>> Post([FromBody] CreateClienteRequest request)
        {
            if (_context.Clientes == null)
                return Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");

            var clinica = request.CreateFromRequest(_userInfo.UserId);

            _context.Clientes.Add(clinica);
            await _context.SaveChangesAsync();

            var response = clinica.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
