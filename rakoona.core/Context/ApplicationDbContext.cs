using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Context.Configs;
using rakoona.core.Context.Seeds;
using rakoona.core.Entities.Maps;
using rakoona.core.Entities.Maps.Consultas;
using rakoona.core.Entities.Maps.Consultas.Mediciones;
using rakoona.core.Entities.Maps.Pacientes;
using rakoona.core.Entities.Maps.Personas;
using rakoona.core.Entities.Maps.TiposDeContacto;
using rakoona.core.Entities.Models;
using rakoona.core.Entities.Models.Consultas;
using rakoona.core.Entities.Models.Consultas.Mediciones;
using rakoona.core.Entities.Models.Pacientes;
using rakoona.core.Entities.Models.Personas;
using rakoona.core.Entities.Models.Seguridad;
using rakoona.core.Entities.Models.TiposDeContacto;

namespace rakoona.core.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityModelCreating.Config(builder);

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
            builder.ApplyConfiguration(new ColorMap());
            builder.ApplyConfiguration(new ImagenPorMascotaMap());
            builder.ApplyConfiguration(new MedicionDeFrecuenciaRespiratoriaMap());
            builder.ApplyConfiguration(new MedicionDePesoMap());
            builder.ApplyConfiguration(new MedicionDePulsoMap());
            builder.ApplyConfiguration(new MedicionDeRitmoCardiacoMap());
            builder.ApplyConfiguration(new MedicionDeTemperaturaMap());
            builder.ApplyConfiguration(new CitaMap());
            builder.ApplyConfiguration(new OrganizacionMap());
            builder.ApplyConfiguration(new CartillaMap());
            builder.ApplyConfiguration(new ClaseDeAnimalesMap());
            builder.ApplyConfiguration(new EspecieMap());
            builder.ApplyConfiguration(new FamiliaMap());
            builder.ApplyConfiguration(new GeneroAnimalMap());
            builder.ApplyConfiguration(new OrdenAnimalMap());
            builder.ApplyConfiguration(new RazaAnimalMap());
            builder.ApplyConfiguration(new DescripcionFisicaDeMascotaMap());

            OrdenAnimalDBInitializer.Seed(builder);
            ClaseAnimalDBInitializer.Seed(builder);
            FamiliaDBInitializer.Seed(builder);
            GeneroDBInitializer.Seed(builder);
            EspecieDBInitializer.Seed(builder);
            RazaAnimalDBInitializer.Seed(builder);
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
        internal DbSet<PlanDeVacunacion>? Vacunas { get; set; }
        internal DbSet<Contacto>? InformacionDeContacto { get; set; }
        internal DbSet<Domicilio>? Domicilios { get; set; }
        internal DbSet<Color>? ColoresPorMascotas { get; set; }
        internal DbSet<ImagenPorMascota>? ImagenesPorMascotas { get; set; }
        internal DbSet<MedicionDeFrecuenciaRespiratoria>? MedicionDeFrecuenciaRespiratoria { get; set; }
        internal DbSet<MedicionDePeso>? MedicionDePeso { get; set; }
        internal DbSet<MedicionDePulso>? MedicionesDePulso { get; set; }
        internal DbSet<MedicionDeRitmoCardiaco>? MedicionesDeRitmoCardiaco { get; set; }
        internal DbSet<MedicionDeTemperatura>? MedicionesDeTemperatura { get; set; }
        internal DbSet<Cita>? Citas { get; set; }
        internal DbSet<Organizacion>? Organizacion { get; set; }
        internal DbSet<Cartilla>? Cartilla { get; set; }
        internal DbSet<ClaseDeAnimales>? ClaseAnimal { get; set; }
        internal DbSet<Especie>? Especie { get; set; }
        internal DbSet<Familia>? Familia { get; set; }
        internal DbSet<GeneroAnimal>? GeneroAnimal { get; set; }
        internal DbSet<OrdenAnimal>? OrdenAnimal { get; set; }
        internal DbSet<RazaAnimal>? RazaAnimal { get; set; }
        internal DbSet<DescripcionFisicaDeMascota>? DescripcionFisicaDeMascota { get; set; }
    }
}
