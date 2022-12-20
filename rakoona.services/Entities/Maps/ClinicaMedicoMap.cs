using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    public class ClinicaMedicoMap : IEntityTypeConfiguration<ClinicaMedico>
    {
        public void Configure(EntityTypeBuilder<ClinicaMedico> builder)
        {
            builder.ToTable(name: "ClinicaMedicos");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ClinicaId).HasColumnName("ClinicaId");
            builder.Property(c => c.MedicoId).HasColumnName("MedicoId");

            #endregion

            #region Discriminator

            #endregion

            #region HasOne

            builder.HasOne(bc => bc.Clinica)
                .WithMany(c => c.ClinicaMedicos)
                .HasForeignKey(bc => bc.ClinicaId);

            builder.HasOne(bc => bc.Medico)
                .WithMany(c => c.ClinicaMedicos)
                .HasForeignKey(bc => bc.MedicoId);
            #endregion
        }

    }
}
