using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class UpdateClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UpdateClinicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PUT: api/Clinicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [SwaggerOperation(Tags = new[] { "Clinicas" })]
        public async Task<IActionResult> Put(int id, Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return BadRequest();
            }

            _context.Entry(clinica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClinicaExists(int id)
        {
            return (_context.Clinicas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
