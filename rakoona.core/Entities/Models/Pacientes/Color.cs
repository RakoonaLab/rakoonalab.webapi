using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class Color : ModelBase
    {
        public int DescripcionRef { get; set; }
        public virtual DescripcionFisicaDeMascota Descripcion { get; set; }
    }

    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable(name: "ColoresPorMascota");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");


        }

    }
}
