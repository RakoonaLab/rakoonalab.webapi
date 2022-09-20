using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Personas;

namespace rakoona.webapiapplication.Entities.Maps.Personas
{
    public class PersonaMap : IEntityTypeConfiguration<PersonaBase>
    {
        public void Configure(EntityTypeBuilder<PersonaBase> builder)
        {
            builder.ToTable(name: "Personas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.PrimerNombre).HasColumnName("PrimerNombre");
            builder.Property(c => c.SegundoNombre).HasColumnName("SegundoNombre");
            builder.Property(c => c.PrimerApellido).HasColumnName("PrimerApellido");
            builder.Property(c => c.SegundoApellido).HasColumnName("SegundoApellido");
            builder.Property(c => c.Nacimiento).HasColumnName("Nacimiento");

            #endregion

            #region Discriminator

            #endregion



            #region HasOne
            builder.HasOne(a => a.User)
                .WithOne(b => b.Persona)
                .HasForeignKey<PersonaBase>(b => b.UsuarioRef);

            #endregion


        }

    }
}
