using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class DescripcionFisicaDeMascota : ModelBase
    {
        public int RazaRef { get; set; }
        public int MascotaRef { get; set; }
        public virtual RazaAnimal Raza { get; set; }
        public virtual Mascota Mascota { get; set; }
        public virtual IEnumerable<Color> Colores { get; set; }
    }

    public class DescripcionFisicaDeMascotaMap : IEntityTypeConfiguration<DescripcionFisicaDeMascota>
    {
        public void Configure(EntityTypeBuilder<DescripcionFisicaDeMascota> builder)
        {
            builder.ToTable(name: "DescripcionesFisicasDeMascotas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.HasOne(x => x.Raza)
                .WithMany(x => x.DescipcionesFisicasDeMascota)
                .HasForeignKey(x => x.RazaRef);

            builder.HasOne(x => x.Mascota)
                .WithOne(x => x.Descripcion)
                .HasForeignKey<DescripcionFisicaDeMascota>(x => x.MascotaRef);

            builder.HasMany(c => c.Colores)
                .WithOne(x => x.Descripcion)
                .HasForeignKey(x => x.DescripcionRef);
        }
    }
}
