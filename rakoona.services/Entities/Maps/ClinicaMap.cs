using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    public class ClinicaMap : IEntityTypeConfiguration<Clinica>
    {
        public void Configure(EntityTypeBuilder<Clinica> builder)
        {
            builder.ToTable(name: "Clinicas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre").HasMaxLength(250);
            builder.Property(c => c.UserRef).HasColumnName("UserRef").HasMaxLength(250);

            #endregion

            #region Discriminator

            #endregion

            #region HasOne

            builder.HasOne(a => a.Usuario)
                    .WithMany(b => b.Clinicas)
                    .HasForeignKey(b => b.UserRef);

            #endregion
        }

    }
}
