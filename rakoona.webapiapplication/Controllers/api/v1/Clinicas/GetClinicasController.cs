﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using rakoona.services.Entities.Mappers;

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
        [SwaggerOperation(Tags = new[] { "Clinica" })]
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
