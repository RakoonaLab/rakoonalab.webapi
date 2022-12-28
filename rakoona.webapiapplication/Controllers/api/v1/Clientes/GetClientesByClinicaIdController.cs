using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.services.Context;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;
using rakoona.services.Entities.Mappers;

namespace rakoona.webapiapplication.Controllers.api.v1.Clientes
{
    [Route("api/clinica/{clinicaId}/clientes")]
    [Authorize]
    [ApiController]
    public class GetClientesByClinicaIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetClientesByClinicaIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes", "Clinicas" })]
        public async Task<ActionResult<List<ClienteResponse>>> Get([FromRoute] string clinicaId,
                                                                   [FromQuery] string? nombre = "",
                                                                   [FromQuery] string? celular = "")
        {
            if (_context.ClientesClinicas == null)
            {
                return NotFound();
            }

            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            //var query = _context.ClientesClinicas.Where(x => x.Clinica.UserRef == _userInfo.UserId && x.Clinica.ExternalId == clinicaId)
            //    .Include(x => x.Cliente)
            //    .ThenInclude(x => x.InformacionDeContacto)
            //    .Include(x => x.Cliente)
            //    .ThenInclude(x => x.Mascotas);

            //var query2 = _context.ClientesClinicas.Where(x => x.Clinica.UserRef == _userInfo.UserId && x.Clinica.ExternalId == clinicaId)
            //    .Include(x => x.Cliente)
            //    .ThenInclude(x => x.InformacionDeContacto)
            //    .Include(x => x.Cliente)
            //    .ThenInclude(x => x.Mascotas)
            //    .Select(x => x.Cliente);

            //if (!String.IsNullOrEmpty(celular))
            ////{
            //    var query3 = _context.InformacionDeContacto.Where(x => x.ContactType == "Celular" && x.Valor == "celular");

            //    var query4 = _context.InformacionDeContacto.Where(x => x.ContactType == "Celular" && x.Valor.Contains(celular));

            //    var query5 = _context.Clientes.Where(x => query4.);
            //////}

            //if (!String.IsNullOrEmpty(celular))
            //{
            //    var query3 = _context.InformacionDeContacto.Where(x => x.ContactType== "Celular" && x.Valor == "celular");


            //}

            //.ThenInclude(x => x.InformacionDeContacto)
            //.Include(x => x.Cliente)
            //.ThenInclude(x => x.Mascotas);

            var clientes = _context.ClientesClinicas.Where(x => x.Clinica.UserRef == _userInfo.UserId && x.Clinica.ExternalId == clinicaId)
                .Include(x => x.Cliente)
                .ThenInclude(x => x.InformacionDeContacto)
                .Include(x => x.Cliente)
                .ThenInclude(x => x.Mascotas);
            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes.Select(x => x.Cliente.MapToResponse()).ToList());
        }

    }
}
