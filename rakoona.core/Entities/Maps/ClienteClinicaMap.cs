using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models;

namespace rakoona.core.Entities.Maps
{
    public class ClienteClinicaMap : IEntityTypeConfiguration<ClienteClinica>
    {
        public void Configure(EntityTypeBuilder<ClienteClinica> builder)
        {
            builder.ToTable(name: "ClienteClinica");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ClinicaId).HasColumnName("ClinicaId");
            builder.Property(c => c.ClienteId).HasColumnName("ClienteId");

            #endregion

            #region Discriminator

            #endregion

            #region HasOne

            builder.HasOne(bc => bc.Clinica)
                .WithMany(c => c.ClienteClinicas)
                .HasForeignKey(bc => bc.ClinicaId);

            builder.HasOne(bc => bc.Cliente)
                .WithMany(c => c.ClienteClinicas)
                .HasForeignKey(bc => bc.ClienteId);
            #endregion
        }

    }
}
