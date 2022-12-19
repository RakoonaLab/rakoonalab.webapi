using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.services.Dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
{
    [Route("api/clinicas")]
    [Authorize]
    [ApiController]
    public class GetClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetClientesController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clinicas" })]
        public async Task<ActionResult<List<ClinicaResponse>>> Get()
        {
            if (_context.Clinicas == null)
            {
                return NotFound();
            }
            var clinicas = _context.Clinicas.Where(x=> x.UserRef == _userInfo.UserId).ToList();

            if (clinicas == null)
            {
                return NotFound();
            }

            PagedResponse<List<Clinica>> response = new PagedResponse<List<Clinica>>();
            response.Count = clinicas.Count;
            response.Items = clinicas;

            return Ok(clinicas.Select(x=> x.MapToResponse()).ToList());
        }

    }
}
