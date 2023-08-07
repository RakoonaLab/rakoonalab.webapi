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
                    .SetIsOriginAllowed(origin => true)
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
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials();
                }));
            }
        }
    }
}
