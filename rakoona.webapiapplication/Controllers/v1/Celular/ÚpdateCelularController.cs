using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Clientes;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Celular
{
    [Route("api/celular/{celularId}")]
    [Authorize]
    [ApiController]
    public class ÚpdateCelularController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public ÚpdateCelularController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Celular" })]
        public async Task<ActionResult<ConsultaPreventivaResponse>> Put([FromBody] UpdateCelularRequest request, [FromRoute] string celularId)
        {
            var celular = _context.InformacionDeContacto.FirstOrDefault(x => x.ExternalId == celularId && x.ContactType == "Celular");

            if (celular == null)
                return StatusCode(StatusCodes.Status404NotFound, "contacto no encontrad0");

            var updated = request.UpdateFromRequest(celular);

            _context.Update(updated);
            await _context.SaveChangesAsync();

            var response = updated.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
