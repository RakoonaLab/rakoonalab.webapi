using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Seguridad;
using rakoona.core.Entities.Models.TiposDeContacto;

namespace rakoona.core.Entities.Models.Personas
{
    public class Persona : ModelBase
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string? UsuarioRef { get; set; }
        public virtual User? User { get; set; }
        public virtual Medico? MedicoInfo { get; set; }
        public List<Contacto>? InformacionDeContacto { get; set; }
        public List<Domicilio>? Domicilios { get; set; }

        public string GetNombreCompleto()
        {
            var nombreCompleto = Nombres;
            nombreCompleto += Apellidos != "" ? " " + Apellidos : Apellidos;
            return nombreCompleto;
        }
    }

    public class PersonaMap : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable(name: "Personas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombres).HasColumnName("Nombres");
            builder.Property(c => c.Apellidos).HasColumnName("Apellidos");
            builder.Property(c => c.FechaDeNacimiento).HasColumnName("FechaDeNacimiento");


            builder.HasOne(a => a.User)
                .WithOne(b => b.Persona)
                .HasForeignKey<Persona>(b => b.UsuarioRef);

            builder.HasMany(a => a.InformacionDeContacto)
                .WithOne(b => b.Persona)
                .HasForeignKey(b => b.PersonaRef);

            builder.HasMany(a => a.Domicilios)
                .WithOne(b => b.Persona)
                .HasForeignKey(b => b.PersonaRef);

            builder.HasOne(a => a.MedicoInfo)
                .WithOne(b => b.PersonaInfo)
                .HasForeignKey<Medico>(b => b.PersonaRef);


        }

    }
}
