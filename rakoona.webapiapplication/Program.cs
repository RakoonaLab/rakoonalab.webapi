using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using rakoona.services.Entities.Models.Seguridad;
using rakoona.webapi.Configuration;
using rakoona.webapi.Configuration.Models;
using rakoona.services.Context;
using System.Text;
using rakoona.services.Services.Interfaces;
using rakoona.services.Services.Implementacion;
using rakoona.webapi.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

Database.ConfigConnectionString(ref builder);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});


builder.Services.AddControllers();
builder.Services.AddTransient<IUserInfoService, UserInfoService>();
builder.Services.AddTransient<IDomicilioService, DomicilioService>();
builder.Services.AddTransient<IMascotaService, MascotaService>();
builder.Services.AddTransient<IVacunaService, VacunaService>();
builder.Services.AddTransient<IClienteService, ClienteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Rakoona-APIs",
        Description = "Rakoona-APIs.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", builder =>
{
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:4200")
    .AllowCredentials();
}));

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{

}
if (app.Environment.IsProduction())
{
    var port = Environment.GetEnvironmentVariable("PORT");
    app.Urls.Add($"http://*:{port}");
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
