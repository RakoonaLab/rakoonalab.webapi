namespace rakoona.webapi.Configuration
{
    public class CORS
    {
        public static void Config(ref WebApplicationBuilder builder) {
            var site = builder.Environment.IsDevelopment() ? "http://localhost:4200" : "https://thechanec.github.io/";

            builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(site)
                .AllowCredentials();
            }));
        }
    }
}
