using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Context;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class DeleteClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeleteClinicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // DELETE: api/Clinicas/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Tags = new[] { "Clinicas" })]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Clinicas == null)
            {
                return NotFound();
            }
            var clinica = await _context.Clinicas.FindAsync(id);
            if (clinica == null)
            {
                return NotFound();
            }

            _context.Clinicas.Remove(clinica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
