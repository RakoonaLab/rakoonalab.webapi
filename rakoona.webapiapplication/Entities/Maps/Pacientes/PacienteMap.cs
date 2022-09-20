using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Pacientes;

namespace rakoona.webapiapplication.Entities.Maps.Pacientes
{
    public class PacienteMap : IEntityTypeConfiguration<PacienteBase>
    {
        public void Configure(EntityTypeBuilder<PacienteBase> builder)
        {
            builder.ToTable(name: "Pacientes");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.Nombre).HasColumnName("Nombre");

            #endregion

            #region Discriminator

            #endregion



            #region HasOne

            #endregion


        }

    }
}
