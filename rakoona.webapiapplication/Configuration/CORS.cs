namespace rakoona.webapi.Configuration
{
    public class CORS
    {
        public static void Config(ref WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", builder =>
                {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200")
                    .AllowCredentials();
                }));
            }
            else
            {
                builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", builder =>
                {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200",
                                "https://rakoona-aca32.firebaseapp.com/",
                                    "https://rakoona-aca32.web.app/")
                    .AllowCredentials();
                }));
            }
        }
    }
}
