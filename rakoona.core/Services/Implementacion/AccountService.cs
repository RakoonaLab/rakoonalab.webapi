using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using rakoona.core.Context;
using rakoona.core.Entities.Models;
using rakoona.core.Entities.Models.Seguridad;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace rakoona.core.Services.Implementacion
{
    public class AccountService : IAccountService
    {
        private ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AccountService(ApplicationDbContext context,
            IConfiguration configuration,
            UserManager<User> userManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<bool> ValidateIfUserExist(string email)
        {
            var userExists = await _userManager.FindByEmailAsync(email);
            if (userExists != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TokenResponse?> Login(AuthenticateRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            var passwordIsValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user != null && passwordIsValid)
            {

                if (user.EmailConfirmed)
                {

                }

                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new TokenResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            return null;
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Response> Register(RegisterRequest model)
        {
            var plan = await _context.Planes.Include(x => x.Precios).Where(x => x.Nombre == "Free").SingleAsync();
            var now = DateTime.Now;
            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Organizacion = new Organizacion()
                {
                    ExternalId = Guid.NewGuid().ToString()
                },
                Subscripciones = new List<Subscripcion> {
                    new Subscripcion {
                        ExternalId = Guid.NewGuid().ToString(),
                        PrecioRef = plan.Precios.FirstOrDefault().Id,
                        FechaDeCreacion = now,
                        Inicio = now
                    }
                }
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new Response { Status = "Error", Errors = result.Errors.Select(x => x.Description) };

            return new Response { Status = "Success" };
        }
    }
}
