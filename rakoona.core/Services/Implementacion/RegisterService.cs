using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Context;
using rakoona.core.Entities.Models;
using rakoona.core.Entities.Models.Seguridad;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Implementacion
{
    public class RegisterService : IRegisterService
    {
        private ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public RegisterService(ApplicationDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
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
