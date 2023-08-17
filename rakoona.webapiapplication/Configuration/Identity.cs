using Microsoft.AspNetCore.Identity;
using rakoona.core.Context;
using rakoona.core.Entities.Models.Seguridad;

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
