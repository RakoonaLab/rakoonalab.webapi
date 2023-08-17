using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class Especie : ModelBase
    {
        public string? NombreCientifico { get; set; }
        public string? NombreCorto { get; set; }
        public int GeneroRef { get; set; }
        public int OrdenAnimalRef { get; set; }
        public int ClaseAnimalRef { get; set; }


        public virtual GeneroAnimal Genero { get; set; }
        public virtual OrdenAnimal Orden { get; set; }
        public virtual ClaseDeAnimales ClaseAnimal { get; set; }
        public virtual IEnumerable<RazaAnimal> Razas { get; set; }

    }

    public class EspecieMap : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.ToTable(name: "Especies");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.NombreCientifico).HasColumnName("NombreCientifico");
            builder.Property(c => c.NombreCorto).HasColumnName("NombreCorto");
            builder.Property(c => c.GeneroRef).HasColumnName("GeneroRef");
            builder.Property(c => c.OrdenAnimalRef).HasColumnName("OrdenAnimalRef");
            builder.Property(c => c.ClaseAnimalRef).HasColumnName("ClaseAnimalRef");

            builder.HasOne(x => x.Genero)
                .WithMany(x => x.Especies)
                .HasForeignKey(x => x.GeneroRef);

            builder.HasOne(x => x.Orden)
                .WithMany(x => x.Especies)
                .HasForeignKey(x => x.OrdenAnimalRef);

            builder.HasOne(x => x.ClaseAnimal)
                .WithMany(x => x.Especies)
                .HasForeignKey(x => x.ClaseAnimalRef);

            builder.HasMany(x => x.Razas)
                .WithOne(x => x.Especie)
                .HasForeignKey(x => x.EspecieRef);
        }
    }
}
