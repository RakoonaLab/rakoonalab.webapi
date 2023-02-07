using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Maps.Pacientes
{
    public class ColorPorMascotaMap : IEntityTypeConfiguration<ColorPorMascota>
    {
        public void Configure(EntityTypeBuilder<ColorPorMascota> builder)
        {
            builder.ToTable(name: "Macotas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");
            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");

            builder.HasOne(a => a.Mascota)
                   .WithMany(b => b.Colores)
                   .HasForeignKey(b => b.MascotaRef);
        }

    }
}
