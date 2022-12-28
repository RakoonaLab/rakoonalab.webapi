using Microsoft.EntityFrameworkCore;
using rakoona.services.Context;

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
