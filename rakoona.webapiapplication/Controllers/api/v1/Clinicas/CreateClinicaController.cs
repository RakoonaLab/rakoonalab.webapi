using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class CreateClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;
        public CreateClinicaController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Clinicas" })]
        public async Task<ActionResult<ClinicaResponse>> Post([FromBody] CreateClinicaRequest request)
        {
            if (_context.Clinicas == null)
                return Problem("Entity set 'ApplicationDbContext.Clinicas'  is null.");

            var clinicas = _context.Clinicas.Where(x => x.UserRef == _userInfo.UserId).ToList();

            if (clinicas == null)
            {
                return NotFound();
            }

            var clinica = request.CreateFromRequest(_userInfo.UserId);

            _context.Clinicas.Add(clinica);
            await _context.SaveChangesAsync();

            var response = clinica.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
