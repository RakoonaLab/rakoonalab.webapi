namespace rakoona.webapi.Configuration
{
    public class CORS
    {
        public static void Config(ref WebApplicationBuilder builder) {
            builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4200")
                .AllowCredentials();
            }));

        }
    }
}
