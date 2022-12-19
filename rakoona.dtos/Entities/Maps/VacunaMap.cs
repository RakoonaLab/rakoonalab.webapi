using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    public class VacunaMap : IEntityTypeConfiguration<Vacuna>
    {
        public void Configure(EntityTypeBuilder<Vacuna> builder)
        {
            builder.ToTable(name: "Vacunas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.Nombre).HasColumnName("Nombre");
            builder.Property(c => c.Lote).HasColumnName("Lote");

            #endregion

            #region Discriminator

            #endregion

            #region HasOne
            builder.HasOne(a => a.Consulta)
                    .WithMany(b => b.Vacunas)
                    .HasForeignKey(b => b.ConsultaRef);
            #endregion


        }

    }
}
