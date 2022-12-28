﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Response;
using rakoona.services.Mappers;
using rakoona.services.Context;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clientes
{
    [Route("api/cliente/{clienteId}")]
    [Authorize]
    [ApiController]
    public class GetClienteByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetClienteByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes/5
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes" })]
        public async Task<ActionResult<ClienteResponse>> Get(string clienteId)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = _context.Clientes.Where(x => x.ExternalId == clienteId)
                .Include(x=> x.InformacionDeContacto)
                .First();

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente.MapToResponse());
        }

    }
}
