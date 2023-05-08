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
                var connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
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
