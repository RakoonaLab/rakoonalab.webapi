﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Mascota
{
    [Route("api/cliente/{clienteId}/mascota")]
    [Authorize]
    [ApiController]
    public class CreatePacienteConClienteIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;
        public CreatePacienteConClienteIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        public async Task<ActionResult<PacienteResponse>> Post([FromBody] CreatePacienteRequest request, [FromRoute] string clienteId)
        {
            if (_context.Mascotas == null)
                return Problem("Entity set 'ApplicationDbContext.Pacientes'  is null.");


            var cliente = _context.Clientes.Single(x => x.ExternalId == clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            var paciente = request.CreateFromRequest(cliente.Id);

            _context.Mascotas.Add(paciente);
            await _context.SaveChangesAsync();

            var response = paciente.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
