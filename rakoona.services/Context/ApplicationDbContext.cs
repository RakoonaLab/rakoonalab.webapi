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
            builder.ApplyConfiguration(new ConsultaBasicaMap());
            builder.ApplyConfiguration(new ConsultaPreventivaMap());
            builder.ApplyConfiguration(new MascotaMap());
            builder.ApplyConfiguration(new PersonaMap());
            
            builder.ApplyConfiguration(new DosisMap());
            builder.ApplyConfiguration(new RecetaMap());
            builder.ApplyConfiguration(new VacunaMap());
            builder.ApplyConfiguration(new ContactoMap());
            builder.ApplyConfiguration(new DomicilioMap());
        }

        public DbSet<User>? Usuarios { get; set; }
        public DbSet<ConsultaBasica>? ConsultaBasica { get; set; }
        public DbSet<ConsultaPreventiva>? ConsultaPreventiva { get; set; }
        public DbSet<Mascota>? Mascotas { get; set; }
        public DbSet<Medico>? Medicos { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<PersonaBase>? Personas { get; set; }
        public DbSet<Clinica>? Clinicas { get; set; }
        public DbSet<Dosis>? Dosis { get; set; }
        public DbSet<Receta>? Recetas { get; set; }
        public DbSet<ClinicaMedico>? ClinicasMedicos { get; set; }
        public DbSet<ClienteClinica>? ClientesClinicas { get; set; }
        public DbSet<Vacuna>? Vacunas { get; set; }
        public DbSet<Contacto>? InformacionDeContacto { get; set; }
        public DbSet<Domicilio>? Domicilios { get; set; }
    }
}
