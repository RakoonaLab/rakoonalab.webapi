using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapi.Entities.Models;

namespace rakoona.webapi.Entities.Maps
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

            #endregion

            #region Discriminator

            #endregion

            #region HasOne
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.Vacunas)
                    .HasForeignKey(b => b.MascotaRef);
            #endregion


        }

    }
}
