using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class ClaseDeAnimales : ModelBase
    {
        public string Nombre { get; set; }
        public virtual IEnumerable<Especie> Especies { get; set; }
    }

    public class ClaseDeAnimalesMap : IEntityTypeConfiguration<ClaseDeAnimales>
    {
        public void Configure(EntityTypeBuilder<ClaseDeAnimales> builder)
        {
            builder.ToTable(name: "ClasesDeAnimales");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");

            builder.HasMany(x => x.Especies)
                .WithOne(x => x.ClaseAnimal)
                .HasForeignKey(x => x.ClaseAnimalRef);
        }
    }
}
