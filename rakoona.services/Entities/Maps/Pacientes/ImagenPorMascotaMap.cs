using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Maps.Pacientes
{
    public class ImagenPorMascotaMap : IEntityTypeConfiguration<ImagenPorMascota>
    {
        public void Configure(EntityTypeBuilder<ImagenPorMascota> builder)
        {
            builder.ToTable(name: "ImagenesPorMascota");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.FileName).HasColumnName("FileName");
            builder.Property(c => c.FileType).HasColumnName("FileType");
            builder.Property(c => c.FileData).HasColumnName("FileData");

            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");

            builder.HasOne(a => a.Mascota)
                   .WithMany(b => b.Imagenes)
                   .HasForeignKey(b => b.MascotaRef);
        }

    }
}