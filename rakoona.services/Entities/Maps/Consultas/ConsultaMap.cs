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
            builder.Property(c => c.Motivo).HasColumnName("Motivo");
            builder.Property(c => c.Observaciones).HasColumnName("Observaciones");
            builder.Property(c => c.Diagnostico).HasColumnName("Diagnostico");
            builder.Property(c => c.FechaAplicacion).HasColumnName("FechaAplicacion");


            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");
            builder.Property(c => c.MedicoRef).HasColumnName("MedicoRef");
            builder.Property(c => c.PesoRef).HasColumnName("PesoRef");
            builder.Property(c => c.TemperaturaRef).HasColumnName("TemperaturaRef");
            builder.Property(c => c.PulsoRef).HasColumnName("PulsoRef");
            builder.Property(c => c.RitmoCardiacoRef).HasColumnName("RitmoCardiacoRef");
            builder.Property(c => c.FrecuenciaRespiratoriaRef).HasColumnName("FrecuenciaRespiratoriaRef");


            #endregion


            #region HasOne
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.Consultas)
                    .HasForeignKey(b => b.MascotaRef)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Medico)
                    .WithMany(b => b.Consultas)
                    .HasForeignKey(b => b.MedicoRef)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Peso)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey<Consulta>(b => b.PesoRef);

            builder.HasOne(a => a.Temperatura)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey<Consulta>(b => b.TemperaturaRef);

            builder.HasOne(a => a.Pulso)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey<Consulta>(b => b.PulsoRef);

            builder.HasOne(a => a.RitmoCardiaco)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey<Consulta>(b => b.RitmoCardiacoRef);

            builder.HasOne(a => a.FrecuenciaRespiratoria)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey<Consulta>(b => b.FrecuenciaRespiratoriaRef);

            #endregion

            #region HasMany
            builder.HasMany(a => a.Vacunas)
                    .WithOne(b => b.Consulta)
                    .HasForeignKey(b => b.ConsultaRef)
                    .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }

    }
}
