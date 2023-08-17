using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models.Consultas;
using rakoona.core.Entities.Models.Consultas.Mediciones;
using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models.Pacientes
{
    public class Mascota : ModelBase
    {
        public string Nombre { get; set; }
        public string? Genero { get; set; }
        public int? DiaNacimiento { get; set; }
        public int? MesNacimiento { get; set; }
        public int? AnioNacimiento { get; set; }
        public int DuenioRef { get; set; }

        public virtual Cliente Duenio { get; set; }
        public virtual Cartilla Cartilla { get; set; }
        public virtual DescripcionFisicaDeMascota Descripcion { get; set; }

        public virtual IEnumerable<ImagenPorMascota>? Imagenes { get; set; }
        public virtual IEnumerable<MedicionDePeso>? MedicionesDePeso { get; set; }
        public virtual IEnumerable<MedicionDePulso>? MedicionesDePulso { get; set; }
        public virtual IEnumerable<MedicionDeRitmoCardiaco>? MedicionesDeRitmoCardiaco { get; set; }
        public virtual IEnumerable<MedicionDeTemperatura>? MedicionesDeTemperatura { get; set; }
        public virtual IEnumerable<MedicionDeFrecuenciaRespiratoria>? MedicionesDeFrecuenciaRespiratoria { get; set; }
        public virtual IEnumerable<Cita>? Citas { get; set; }
    }

    public class MascotaMap : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable(name: "Macotas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");
            builder.Property(c => c.Genero).HasColumnName("Genero");
            builder.Property(c => c.DiaNacimiento).HasColumnName("DiaNacimiento");
            builder.Property(c => c.MesNacimiento).HasColumnName("MesNacimiento");
            builder.Property(c => c.AnioNacimiento).HasColumnName("AnioNacimiento");
            builder.Property(c => c.DuenioRef).HasColumnName("DuenioRef");


            builder.HasOne(a => a.Duenio)
                   .WithMany(b => b.Mascotas)
                   .HasForeignKey(b => b.DuenioRef);
        }

    }
}
