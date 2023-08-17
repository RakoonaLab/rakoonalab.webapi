using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace rakoona.services.Entities.Models.Pacientes
{
    public class ImagenPorMascota : ModelBase
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileType { get; set; }
        public bool Principal { get; set; }

        public int MascotaRef { get; set; }
        public virtual Mascota? Mascota { get; set; }
    }

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
