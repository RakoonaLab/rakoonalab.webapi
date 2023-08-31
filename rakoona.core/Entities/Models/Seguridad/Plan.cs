using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace rakoona.core.Entities.Models.Seguridad
{
    public class Plan : ModelBase
    {
        public String Nombre { get; set; }
        public virtual IEnumerable<Precio> Precios { get; set; }
    }

    public class PlanMap : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable(name: "Planes");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");
        }
    }
}
