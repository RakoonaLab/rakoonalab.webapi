using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Vacunas
{
    [Route("api/mascota/{mascotaId}/vacuna")]
    [ApiController]
    public class CreateVacunaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreateVacunaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Vacunas" })]
        public async Task<ActionResult<VacunaResponse>> PostVacuna([FromBody] CreateVacunaRequest request, [FromRoute] string mascotaId)
        {
            if (_context.Vacunas == null)
                return Problem("Entity set 'ApplicationDbContext.Vacunas'  is null.");

            var mascota = _context.Mascotas.Single(x => x.ExternalId == mascotaId);

            if (mascota == null)
            {
                return NotFound();
            }

            var vacuna = request.CreateFromRequest(mascota.Id);

            _context.Vacunas.Add(vacuna);
            await _context.SaveChangesAsync();

            var response = vacuna.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
