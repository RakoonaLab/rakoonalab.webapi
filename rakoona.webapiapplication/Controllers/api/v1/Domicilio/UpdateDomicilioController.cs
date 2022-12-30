using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Domicilio;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Domicilio
{
    [Route("api/domicilio/{domicilioId}")]
    [Authorize]
    [ApiController]
    public class UpdateDomicilioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public UpdateDomicilioController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Domicilio" })]
        public async Task<ActionResult<DomicilioResponse>> Put([FromBody] UpdateDomicilioRequest request, [FromRoute] string domicilioId)
        {
            var domicilio = _context.Domicilios.FirstOrDefault(x => x.ExternalId == domicilioId && x.Principal);

            if (domicilio == null)
                return StatusCode(StatusCodes.Status404NotFound, "contacto no encontrad0");

            var updated = request.UpdateFromRequest(domicilio);

            _context.Update(updated);
            await _context.SaveChangesAsync();

            var response = updated.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
