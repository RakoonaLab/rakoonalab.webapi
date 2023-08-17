using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class Familia : ModelBase
    {
        public string Nombre { get; set; }
        public virtual IEnumerable<GeneroAnimal> Generos { get; set; }
    }

    public class FamiliaMap : IEntityTypeConfiguration<Familia>
    {
        public void Configure(EntityTypeBuilder<Familia> builder)
        {
            builder.ToTable(name: "Familia");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");

            builder.HasMany(x => x.Generos)
                .WithOne(x => x.Familia)
                .HasForeignKey(x => x.FamiliaRef);
        }

    }
}
