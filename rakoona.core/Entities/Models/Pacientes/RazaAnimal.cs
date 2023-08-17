using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class RazaAnimal : ModelBase
    {
        public string? NombreCientifico { get; set; }
        public string NombreColoquial { get; set; }


        public int EspecieRef { get; set; }
        public virtual Especie Especie { get; set; }
        public virtual IEnumerable<DescripcionFisicaDeMascota> DescipcionesFisicasDeMascota { get; set; }
    }

    public class RazaAnimalMap : IEntityTypeConfiguration<RazaAnimal>
    {
        public void Configure(EntityTypeBuilder<RazaAnimal> builder)
        {
            builder.ToTable(name: "Razas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.EspecieRef).HasColumnName("EspecieRef");
            builder.Property(c => c.NombreCientifico).HasColumnName("NombreCientifico").IsRequired(false);
            builder.Property(c => c.NombreColoquial).HasColumnName("NombreColoquial");

            builder.HasOne(x => x.Especie)
                .WithMany(x => x.Razas)
                .HasForeignKey(x => x.EspecieRef);
        }
    }
}
