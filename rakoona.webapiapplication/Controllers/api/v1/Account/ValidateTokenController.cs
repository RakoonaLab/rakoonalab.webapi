using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Clinicas
{
    [Route("api/account/validate-token")]
    [Authorize]
    [ApiController]
    public class ValidateTokenController : ControllerBase
    {
        public ValidateTokenController()
        {
            
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Account" })]
        public async Task<ActionResult<ClinicaResponse>> Get()
        {
            return Ok();
        }

    }
}
