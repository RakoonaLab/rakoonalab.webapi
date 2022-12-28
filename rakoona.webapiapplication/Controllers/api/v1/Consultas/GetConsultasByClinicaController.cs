﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;

namespace rakoona.webapiapplication.Controllers.api.v1.Consultas
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
            if (_context.Consulta == null)
            {
                return NotFound();
            }

            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            var consultas = _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .SelectMany(m => m.Consultas)
                .Include(c => c.Mascota).ThenInclude(m => m.Duenio)
                .ToList();

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
