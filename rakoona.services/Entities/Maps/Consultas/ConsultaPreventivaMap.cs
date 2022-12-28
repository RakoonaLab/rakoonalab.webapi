using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Maps.Consultas
{
    public class ConsultaPreventivaMap : IEntityTypeConfiguration<ConsultaPreventiva>
    {
        public void Configure(EntityTypeBuilder<ConsultaPreventiva> builder)
        {
            builder.ToTable(name: "ConsultasPreventivas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.Peso).HasColumnName("Peso");
            builder.Property(c => c.Motivo).HasColumnName("Motivo");

            builder.Property(c => c.Observaciones).HasColumnName("Observaciones");
            builder.Property(c => c.Fecha).HasColumnName("Fecha");

            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");

            #endregion

            #region Discriminator
            builder.HasDiscriminator<string>("consulta_type")
                .HasValue<ConsultaBasica>("Basica")
                .HasValue<ConsultaPreventiva>("Preventiva");
            #endregion

            #region HasOne
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.ConsultasPreventivas)
                    .HasForeignKey(b => b.MascotaRef);

            #endregion

            #region HasMany
            #endregion
        }

    }
}
