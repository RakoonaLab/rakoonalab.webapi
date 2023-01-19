﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Medicos
{
    [Route("api/medicos/clinica/{clinicaId}")]
    [Authorize]
    [ApiController]
    public class GetMedicosByClinicaIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetMedicosByClinicaIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Medicos", "Clinica" })]
        public async Task<ActionResult<List<MedicoResponse>>> Get([FromRoute] string clinicaId)
        {
            if (_context.Clinicas == null)
            {
                return NotFound();
            }
            var medicos = _context.ClinicasMedicos.Where(x => x.Clinica.UserRef == _userInfo.UserId && x.Clinica.ExternalId == clinicaId).Select(x => x.Medico).ToList();

            if (medicos == null)
            {
                return NotFound();
            }

            return medicos.Select(x => x.MapToResponse()).ToList();
        }

    }
}
