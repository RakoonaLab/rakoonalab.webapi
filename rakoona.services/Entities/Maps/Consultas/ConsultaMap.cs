using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Maps.Consultas
{
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable(name: "Consultas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Peso).HasColumnName("Peso");
            builder.Property(c => c.Temperatura).HasColumnName("Temperatura");
            builder.Property(c => c.RitmoCardiaco).HasColumnName("RitmoCardiaco");
            builder.Property(c => c.FrecuenciaRespiratoria).HasColumnName("FrecuenciaRespiratoria");
            builder.Property(c => c.Pulso).HasColumnName("Pulso");
            builder.Property(c => c.CaracteristicasDelPulso).HasColumnName("CaracteristicasDelPulso");
            builder.Property(c => c.Motivo).HasColumnName("Motivo");
            builder.Property(c => c.Observaciones).HasColumnName("Observaciones");
            builder.Property(c => c.Diagnostico).HasColumnName("Diagnostico");
            builder.Property(c => c.FechaAplicacion).HasColumnName("FechaAplicacion");

            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");
            builder.Property(c => c.MedicoRef).HasColumnName("MedicoRef");

            #endregion

            #region Discriminator
            #endregion

            #region HasOne
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.Consultas)
                    .HasForeignKey(b => b.MascotaRef);

            builder.HasOne(a => a.Medico)
                    .WithMany(b => b.Consultas)
                    .HasForeignKey(b => b.MedicoRef);

            #endregion

            #region HasMany
            builder.HasMany(a => a.Vacunas)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey(b => b.ConsultaRef);
            #endregion
        }

    }
}
