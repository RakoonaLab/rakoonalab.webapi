using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace rakoona.services.Entities.Models.Pacientes
{
    public class GeneroAnimal : ModelBase
    {
        public string Nombre { get; set; }

        public int FamiliaRef { get; set; }
        public virtual Familia Familia { get; set; }
        public virtual IEnumerable<Especie> Especies { get; set; }

    }

    public class GeneroAnimalMap : IEntityTypeConfiguration<GeneroAnimal>
    {
        public void Configure(EntityTypeBuilder<GeneroAnimal> builder)
        {
            builder.ToTable(name: "GeneroAnimal");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");

            builder.HasOne(x => x.Familia)
                .WithMany(x => x.Generos)
                .HasForeignKey(x => x.FamiliaRef);

            builder.HasMany(x => x.Especies)
                .WithOne(x => x.Genero)
                .HasForeignKey(x => x.GeneroRef);
        }

    }
}
