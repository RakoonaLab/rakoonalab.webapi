using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Consultas.Mediciones;

namespace rakoona.services.Entities.Maps.Consultas.Mediciones
{
    public class MedicionDeFrecuenciaRespiratoriaMap : IEntityTypeConfiguration<MedicionDeFrecuenciaRespiratoria>
    {
        public void Configure(EntityTypeBuilder<MedicionDeFrecuenciaRespiratoria> builder)
        {
            builder.ToTable(name: "MedicionDeFrecuenciaRespiratoria");

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
                    .WithMany(b => b.MedicionesDeFrecuenciaRespiratoria)
                    .HasForeignKey(b => b.MascotaRef);
            #endregion
        }
    }
}
