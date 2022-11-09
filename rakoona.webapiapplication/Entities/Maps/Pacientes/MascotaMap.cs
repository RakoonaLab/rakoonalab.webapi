using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Pacientes;

namespace rakoona.webapiapplication.Entities.Maps.Pacientes
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
            builder.Property(c => c.DuenioRef).HasColumnName("DuenioRef");

            #endregion

            #region Discriminator

            #endregion



            #region HasOne

            #endregion


        }

    }
}
