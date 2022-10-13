using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clientes
{
    [Route("api/clientes")]
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
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<PagedResponse<List<Cliente>>>> GetClientes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var clientes = _context.Clientes/*.Where(x=> x. == _userInfo.UserId)*/.ToList();

            if (clientes == null)
            {
                return NotFound();
            }

            PagedResponse<List<Cliente>> response = new PagedResponse<List<Cliente>>();
            response.Count = clientes.Count;
            response.Items = clientes;

            return response;
        }

    }
}
