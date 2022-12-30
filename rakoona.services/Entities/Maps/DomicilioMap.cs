using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    public class DomicilioMap : IEntityTypeConfiguration<Domicilio>
    {
        public void Configure(EntityTypeBuilder<Domicilio> builder)
        {
            builder.ToTable(name: "Domicilios");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Calle).HasColumnName("Calle").HasMaxLength(250);
            builder.Property(c => c.Colonia).HasColumnName("Colonia").HasMaxLength(250);
            builder.Property(c => c.Municipio).HasColumnName("Municipio").HasMaxLength(250);
            builder.Property(c => c.Estado).HasColumnName("Estado").HasMaxLength(250);
            builder.Property(c => c.CP).HasColumnName("CP").HasMaxLength(7);
            builder.Property(c => c.Principal).HasColumnName("Principal");

            #endregion

            #region Discriminator
            
            #endregion

            #region HasOne

            builder.HasOne(a => a.Persona)
                    .WithMany(b => b.Domicilios)
                    .HasForeignKey(b => b.PersonaRef);

            #endregion
        }

    }
}
