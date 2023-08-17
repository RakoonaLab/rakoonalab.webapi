using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models.Consultas.Mediciones;

namespace rakoona.core.Entities.Maps.Consultas.Mediciones
{
    public class MedicionDePesoMap : IEntityTypeConfiguration<MedicionDePeso>
    {
        public void Configure(EntityTypeBuilder<MedicionDePeso> builder)
        {
            builder.ToTable(name: "MedicionDePeso");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.FechaAplicacion).HasColumnName("FechaAplicacion");
            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");
            builder.Property(c => c.Valor).HasColumnName("Valor");
            #endregion

            #region HasOne
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.MedicionesDePeso)
                    .HasForeignKey(b => b.MascotaRef);
            #endregion
        }
    }
}
