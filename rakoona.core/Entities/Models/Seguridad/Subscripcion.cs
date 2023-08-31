using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace rakoona.core.Entities.Models.Seguridad
{
    public class Subscripcion : ModelBase
    {
        public string UserRef { get; set; }
        public int PrecioRef { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }

        public virtual User Usuario { get; set; }
        public virtual Precio Precio { get; set; }
    }

    public class SubscripcionMap : IEntityTypeConfiguration<Subscripcion>
    {
        public void Configure(EntityTypeBuilder<Subscripcion> builder)
        {
            builder.ToTable(name: "Subscripciones");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.UserRef).HasColumnName("UserRef");
            builder.Property(c => c.PrecioRef).HasColumnName("PrecioRef");
            builder.Property(c => c.Inicio).HasColumnName("Inicio");
            builder.Property(c => c.Fin).HasColumnName("Fin");

            builder.HasOne(a => a.Usuario)
                   .WithMany(b => b.Subscripciones)
                   .HasForeignKey(b => b.UserRef);

            builder.HasOne(a => a.Precio)
                   .WithMany(b => b.Subscripciones)
                   .HasForeignKey(b => b.PrecioRef);
        }
    }
}

