using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Maps.Personas
{
    public class PersonaMap : IEntityTypeConfiguration<PersonaBase>
    {
        public void Configure(EntityTypeBuilder<PersonaBase> builder)
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
                .HasForeignKey<PersonaBase>(b => b.UsuarioRef);

            builder.HasMany(a => a.InformacionDeContacto)
                .WithOne(b => b.Persona)
                .HasForeignKey(b => b.PersonaRef);

            builder.HasMany(a => a.Domicilios)
                .WithOne(b => b.Persona)
                .HasForeignKey(b => b.PersonaRef);
        }

    }
}
