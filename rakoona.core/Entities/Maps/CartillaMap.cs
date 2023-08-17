using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models;

namespace rakoona.core.Entities.Maps.Pacientes
{
    public class CartillaMap : IEntityTypeConfiguration<Cartilla>
    {
        public void Configure(EntityTypeBuilder<Cartilla> builder)
        {
            builder.ToTable(name: "Cartillas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");

            builder.HasOne(a => a.Mascota)
                   .WithOne(b => b.Cartilla)
                   .HasForeignKey<Cartilla>(b => b.MascotaRef);
        }
    }
}
