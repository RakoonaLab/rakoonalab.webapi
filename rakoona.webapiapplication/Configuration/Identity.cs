using Microsoft.AspNetCore.Identity;
using rakoona.services.Context;
using rakoona.services.Entities.Models.Seguridad;

namespace rakoona.webapi.Configuration
{
    public class Identity
    {
        public static void Config(ref WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
