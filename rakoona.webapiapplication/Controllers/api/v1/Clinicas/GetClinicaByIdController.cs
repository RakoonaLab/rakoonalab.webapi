using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Context;
using rakoona.services.Entities.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
{
    [Route("api/clinica")]
    [Authorize]
    [ApiController]
    public class GetClinicaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetClinicaByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Clinicas" })]
        public async Task<ActionResult<Clinica>> Get([FromRoute] string id)
        {
            if (_context.Clinicas == null)
            {
                return NotFound();
            }
            var clinica = _context.Clinicas.Single(x=> x.ExternalId == id);

            if (clinica == null)
            {
                return NotFound();
            }

            return clinica;
        }

    }
}
