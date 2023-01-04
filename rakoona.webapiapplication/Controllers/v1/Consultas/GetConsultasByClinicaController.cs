using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas.Preventiva
{
    [Route("api/clinica/{clinicaId}/consultas")]
    [Authorize]
    [ApiController]
    public class GetConsultasByClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultasByClinicaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Clinica" })]
        public async Task<ActionResult<List<ConsultaResponse>>> Get([FromRoute] string clinicaId)
        {
            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            var consultasPreventivas = _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .SelectMany(m => m.ConsultasPreventivas)
                .Include(c => c.Mascota).ThenInclude(m => m.Duenio)
                .ToList();

            var consultasBasicas = _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .SelectMany(m => m.ConsultasBasicas)
                .Include(c => c.Mascota).ThenInclude(m => m.Duenio)
                .ToList();

            var listConsultas = new List<ConsultaResponse>();

            listConsultas.AddRange( consultasPreventivas.Select(x => x.MapToConsultaResponse()).ToList());
            listConsultas.AddRange(consultasBasicas.Select(x => x.MapToConsultaResponse()).ToList());

            return Ok(listConsultas);
        }

    }
}
