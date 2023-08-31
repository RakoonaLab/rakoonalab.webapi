using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace rakoona.core.Entities.Models.Seguridad
{
    public class Precio : ModelBase
    {
        public int PlanRef { get; set; }
        public TipoDeSubscripcion Tipo { get; set; }
        public DateTime ValidoDesde { get; set; }
        public DateTime ValidoHasta { get; set; }
        public decimal Valor { get; set; }

        public virtual Plan Plan { get; set; }
        public virtual IEnumerable<Subscripcion> Subscripciones { get; internal set; }
    }

    public class PrecioMap : IEntityTypeConfiguration<Precio>
    {
        public void Configure(EntityTypeBuilder<Precio> builder)
        {
            builder.ToTable(name: "Precios");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.PlanRef).HasColumnName("PlanRef");
            builder.Property(c => c.ValidoDesde).HasColumnName("ValidoDesde");
            builder.Property(c => c.ValidoHasta).HasColumnName("ValidoHasta");
            builder.Property(c => c.Tipo).HasColumnName("Tipo");

            builder.HasOne(a => a.Plan)
                   .WithMany(b => b.Precios)
                   .HasForeignKey(b => b.PlanRef);
        }
    }
}
