using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Maps;
using rakoona.webapiapplication.Entities.Maps.Consultas;
using rakoona.webapiapplication.Entities.Maps.Pacientes;
using rakoona.webapiapplication.Entities.Maps.Personas;
using rakoona.webapiapplication.Entities.Maps.Seguridad;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Consultas;
using rakoona.webapiapplication.Entities.Models.Pacientes;
using rakoona.webapiapplication.Entities.Models.Personas;
using rakoona.webapiapplication.Entities.Models.Seguridad;

namespace rakoona.webapiapplication.Context
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
            builder.ApplyConfiguration(new ConsultaMap());
            builder.ApplyConfiguration(new PacienteMap());
            builder.ApplyConfiguration(new PersonaMap());
            builder.ApplyConfiguration(new ClinicaMap());
            builder.ApplyConfiguration(new ClinicaMedicoMap());
            builder.ApplyConfiguration(new DosisMap());
            builder.ApplyConfiguration(new RecetaMap());
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<ConsultaBase> Consulta { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<PacienteBase> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PersonaBase> Personas { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Dosis> Dosis { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<ClinicaMedico> ClinicasMedicos { get; set; }
    }
}
