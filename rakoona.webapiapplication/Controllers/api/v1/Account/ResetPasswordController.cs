﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Entities.Models.Seguridad;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using rakoona.webapiapplication.Entities.Dtos.Request;
using Swashbuckle.AspNetCore.Annotations;
using rakoona.webapi.Entities.Dtos.Request;

namespace rakoona.webapiapplication.Controllers.api.v1.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ResetPasswordController> _logger;
        private readonly IEmailSender _emailSender;

        public ResetPasswordController(
            UserManager<User> userManager,
            IConfiguration configuration,
            IEmailSender emailSender,
            ILogger<ResetPasswordController> logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _emailSender = emailSender;
        }

        [SwaggerOperation(Tags = new[] { "Account" })]
        [HttpPost]
        public async Task<IActionResult> OnPostAsync([FromBody] ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToPage("./ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, request.Code, request.Password);
            if (result.Succeeded)
            {
                return RedirectToPage("./ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Ok();
        }
    }
}
