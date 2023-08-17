using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models.Consultas;

namespace rakoona.core.Entities.Maps.Consultas
{
    internal class CitaMap : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable(name: "Citas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Fecha).HasColumnName("Fecha");
            builder.Property(c => c.Comentarios).HasColumnName("Comentarios");

            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");

            #endregion

            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.Citas)
                    .HasForeignKey(b => b.MascotaRef)
                    .OnDelete(DeleteBehavior.NoAction);
        }

    }
}