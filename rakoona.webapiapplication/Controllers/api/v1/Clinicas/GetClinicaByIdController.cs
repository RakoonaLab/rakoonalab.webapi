using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class GetClinicaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetClinicaByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clinicas/5
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Clinicas" })]
        public async Task<ActionResult<Clinica>> GetClinica(int id)
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

            return clinica;
        }

    }
}
