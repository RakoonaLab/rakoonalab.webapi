using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rakoona.services.Entities.Maps;
using rakoona.services.Entities.Maps.Consultas;
using rakoona.services.Entities.Maps.Pacientes;
using rakoona.services.Entities.Maps.Personas;
using rakoona.services.Entities.Maps.Seguridad;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Consultas.Mediciones;
using rakoona.services.Entities.Models.Pacientes;
using rakoona.services.Entities.Models.Personas;
using rakoona.services.Entities.Models.Seguridad;
using rakoona.services.Entities.Models.TiposDeContacto;

namespace rakoona.services.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>(entity =>
            {
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {

            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {

            });

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ClinicaMap());
            builder.ApplyConfiguration(new ClinicaMedicoMap());
            builder.ApplyConfiguration(new ClienteClinicaMap());
            builder.ApplyConfiguration(new ConsultaMap());
            builder.ApplyConfiguration(new MascotaMap());
            builder.ApplyConfiguration(new PersonaMap());
            builder.ApplyConfiguration(new DosisMap());
            builder.ApplyConfiguration(new RecetaMap());
            builder.ApplyConfiguration(new VacunacionMap());
            builder.ApplyConfiguration(new ContactoMap());
            builder.ApplyConfiguration(new DomicilioMap());
            builder.ApplyConfiguration(new ColorPorMascotaMap());
            builder.ApplyConfiguration(new ImagenPorMascotaMap());

            builder.ApplyConfiguration(new MedicionDeFrecuenciaRespiratoriaMap());
            builder.ApplyConfiguration(new MedicionDePesoMap());
            builder.ApplyConfiguration(new MedicionDePulsoMap());
            builder.ApplyConfiguration(new MedicionDeRitmoCardiacoMap());
            builder.ApplyConfiguration(new MedicionDeTemperaturaMap());
            builder.ApplyConfiguration(new CitaMap());
        }

        internal DbSet<User>? Usuarios { get; set; }
        internal DbSet<Consulta>? Consultas { get; set; }
        internal DbSet<Mascota>? Mascotas { get; set; }
        internal DbSet<Medico>? Medicos { get; set; }
        internal DbSet<Cliente>? Clientes { get; set; }
        internal DbSet<PersonaBase>? Personas { get; set; }
        internal DbSet<Clinica>? Clinicas { get; set; }
        internal DbSet<Dosis>? Dosis { get; set; }
        internal DbSet<Receta>? Recetas { get; set; }
        internal DbSet<ClinicaMedico>? ClinicasMedicos { get; set; }
        internal DbSet<ClienteClinica>? ClientesClinicas { get; set; }
        internal DbSet<Vacunacion>? Vacunas { get; set; }
        internal DbSet<Contacto>? InformacionDeContacto { get; set; }
        internal DbSet<Domicilio>? Domicilios { get; set; }
        internal DbSet<ColorPorMascota>? ColoresPorMascotas { get; set; }
        internal DbSet<ImagenPorMascota>? ImagenesPorMascotas { get; set; }
        internal DbSet<MedicionDeFrecuenciaRespiratoria>? MedicionDeFrecuenciaRespiratoria { get; set; }
        internal DbSet<MedicionDePeso>? MedicionDePeso { get; set; }
        internal DbSet<MedicionDePulso>? MedicionesDePulso { get; set; }
        internal DbSet<MedicionDeRitmoCardiaco>? MedicionesDeRitmoCardiaco { get; set; }
        internal DbSet<MedicionDeTemperatura>? MedicionesDeTemperatura { get; set; }
        internal DbSet<Cita>? Citas { get; set; }
    }
}
