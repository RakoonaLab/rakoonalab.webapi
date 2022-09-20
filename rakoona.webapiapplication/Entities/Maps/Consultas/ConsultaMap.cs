using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.webapiapplication.Entities.Models.Consultas;

namespace rakoona.webapiapplication.Entities.Maps.Consultas
{
    public class ConsultaMap : IEntityTypeConfiguration<ConsultaBase>
    {
        public void Configure(EntityTypeBuilder<ConsultaBase> builder)
        {
            builder.ToTable(name: "Consultas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.Observaciones).HasColumnName("Observaciones");
            builder.Property(c => c.Diagnostico).HasColumnName("Diagnostico");
            builder.Property(c => c.Fecha).HasColumnName("Fecha");

            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");

            #endregion

            #region Discriminator

            #endregion

            #region HasOne
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.Consultas)
                    .HasForeignKey(b => b.MascotaRef);

            #endregion

            #region HasMany
            builder.HasMany(a => a.Recetas)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey(b => b.ConsultaRef);
            #endregion
        }

    }
}
