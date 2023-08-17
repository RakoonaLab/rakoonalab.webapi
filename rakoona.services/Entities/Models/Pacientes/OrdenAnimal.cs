using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class OrdenAnimal : ModelBase
    {
        public string Nombre { get; set; }

        public virtual IEnumerable<Especie> Especies { get; set; }
    }

    public class OrdenAnimalMap : IEntityTypeConfiguration<OrdenAnimal>
    {
        public void Configure(EntityTypeBuilder<OrdenAnimal> builder)
        {
            builder.ToTable(name: "OrdenAnimal");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");

            builder.HasMany(c => c.Especies)
                .WithOne(c => c.Orden)
                .HasForeignKey(c => c.OrdenAnimalRef);

        }

    }
}
