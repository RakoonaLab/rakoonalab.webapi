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
            builder.Property(c => c.FechaAplicacion).HasColumnName("FechaAplicacion");
            builder.Property(c => c.Motivo).HasColumnName("Motivo");
            builder.Property(c => c.Observaciones).HasColumnName("Observaciones");
            builder.Property(c => c.Diagnostico).HasColumnName("Diagnostico");

            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");
            builder.Property(c => c.MedicoRef).HasColumnName("MedicoRef");

            #endregion


            
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.Consultas)
                    .HasForeignKey(b => b.MascotaRef)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Medico)
                    .WithMany(b => b.Consultas)
                    .HasForeignKey(b => b.MedicoRef)
                    .OnDelete(DeleteBehavior.NoAction);

            

            
        }

    }
}
