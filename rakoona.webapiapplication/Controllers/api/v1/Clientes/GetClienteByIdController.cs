﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

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
        public async Task<ActionResult<ClienteResponse>> GetCliente(string clienteId)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = _context.Clientes.First(x => x.ExternalId == clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente.MapToResponse();
        }

    }
}
