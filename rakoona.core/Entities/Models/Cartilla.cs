using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Consultas;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models
{
    public class Cartilla : ModelBase
    {
        public int MascotaRef { get; set; }
        public virtual Mascota? Mascota { get; set; }

        public virtual List<Consulta>? Consultas { get; set; }
        public virtual List<PlanDeVacunacion>? PlanesDeVacunacion { get; set; }

    }

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
