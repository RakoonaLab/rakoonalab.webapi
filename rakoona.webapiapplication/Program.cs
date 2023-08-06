using rakoona.webapi.Configuration;
using rakoona.webapi.Configuration.Models;
using rakoona.webapi.Configuration.Swagger;

var builder = WebApplication.CreateBuilder(args);

Database.ConfigConnectionString(ref builder);
Services.ConfigDependencyInjention(ref builder);
Identity.Config(ref builder);
Authentication.Config(ref builder);
Swagger.Config(ref builder);
CORS.Config(ref builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

Database.ApplyMigration(ref app);

app.UseCors("AllowOrigin");
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
