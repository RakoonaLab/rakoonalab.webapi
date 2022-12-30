﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Domicilio;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Domicilio
{
    [Route("api/domicilio/{domicilioId}")]
    [Authorize]
    [ApiController]
    public class UpdateDomicilioController : ControllerBase
    {
        private readonly IDomicilioService _domicilioService;

        public UpdateDomicilioController(IDomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Domicilio" })]
        public async Task<ActionResult<DomicilioResponse>> Put([FromBody] UpdateDomicilioRequest request, [FromRoute] string domicilioId)
        {
            var domicilio = await _domicilioService.ActualizarAsync(request, domicilioId);

            if (domicilio == null)
                return StatusCode(StatusCodes.Status404NotFound, "domicilio no encontrado");

            return StatusCode(StatusCodes.Status200OK, domicilio);
        }

    }
}
