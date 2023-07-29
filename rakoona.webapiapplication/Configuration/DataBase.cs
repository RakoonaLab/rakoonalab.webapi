using Microsoft.EntityFrameworkCore;
using rakoona.services.Context;

namespace rakoona.webapi.Configuration
{
    public class Database
    {
        public static void  ConfigConnectionString(ref WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");

                var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            }
            else
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");

                var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection");
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            }
        }

        public static void ApplyMigration(ref WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
        }
    }
}
