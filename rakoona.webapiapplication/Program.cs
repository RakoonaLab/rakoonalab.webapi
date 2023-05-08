using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using rakoona.services.Context;
using rakoona.webapi.Configuration;
using rakoona.webapi.Configuration.Models;

var builder = WebApplication.CreateBuilder(args);

Database.ConfigConnectionString(ref builder);
Services.ConfigDependencyInjention(ref builder);
Authentication.Config(ref builder);
Swagger.Config(ref builder);
CORS.Config(ref builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    Database.ApplyMigration(ref app);
}
if (app.Environment.IsProduction())
{  
}

app.UseCors("AllowOrigin");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
