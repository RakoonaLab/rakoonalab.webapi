using rakoona.services.Services.Implementacion;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Services;

namespace rakoona.webapi.Configuration
{
    public class Services
    {
        public static void ConfigDependencyInjention(ref WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserInfoService, UserInfoService>();
            builder.Services.AddTransient<IDomicilioService, DomicilioService>();
            builder.Services.AddTransient<IMascotaService, MascotaService>();
            builder.Services.AddTransient<IVacunaService, VacunaService>();
            builder.Services.AddTransient<IClienteService, ClienteService>();
            builder.Services.AddTransient<IConsultaService, ConsultaService>();
            builder.Services.AddTransient<IColoresPorMascotaService, ColoresPorMascotaService>();
            builder.Services.AddTransient<IMedicoService, MedicoService>();
            builder.Services.AddTransient<IClinicaService, ClinicaService>();
            
        }

    }
}
