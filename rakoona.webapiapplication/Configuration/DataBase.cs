using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Models.Seguridad;

namespace rakoona.webapi.Configuration
{
    public class Database
    {
        public static void  ConfigConnectionString(ref WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

    }
}
