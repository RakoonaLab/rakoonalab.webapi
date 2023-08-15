using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps.Pacientes
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


            builder.HasOne(a => a.Mascota)
                   .WithOne(b => b.Cartilla)
                   .HasForeignKey<Cartilla>(b => b.MascotaRef);
        }
    }
}
