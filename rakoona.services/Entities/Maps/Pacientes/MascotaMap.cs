using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Maps.Pacientes
{
    public class MascotaMap : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable(name: "Macotas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.Nombre).HasColumnName("Nombre");
            builder.Property(c => c.Genero).HasColumnName("Genero");
            builder.Property(c => c.Raza).HasColumnName("Raza");
            builder.Property(c => c.Especie).HasColumnName("Especie");

            builder.Property(c => c.DiaNacimiento).HasColumnName("DiaNacimiento");
            builder.Property(c => c.MesNacimiento).HasColumnName("MesNacimiento");
            builder.Property(c => c.AnioNacimiento).HasColumnName("AnioNacimiento");

            builder.Property(c => c.DuenioRef).HasColumnName("DuenioRef");

            #endregion

            #region Discriminator

            #endregion



            #region HasOne
            builder.HasOne(a => a.Duenio)
                   .WithMany(b => b.Mascotas)
                   .HasForeignKey(b => b.DuenioRef);
            #endregion


        }

    }
}
