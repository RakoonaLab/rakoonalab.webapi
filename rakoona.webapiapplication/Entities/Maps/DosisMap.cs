using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.webapiapplication.Entities.Models;

namespace rakoona.webapiapplication.Entities.Maps
{
    public class DosisMap : IEntityTypeConfiguration<Dosis>
    {
        public void Configure(EntityTypeBuilder<Dosis> builder)
        {
            builder.ToTable(name: "Dosis");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.RecetaRef).HasColumnName("RecetaRef");
            builder.Property(c => c.MedicamentoRef).HasColumnName("MedicamentoRef");

            #endregion

            #region Discriminator

            #endregion

            #region HasOne
            builder.HasOne(a => a.Receta)
                    .WithMany(b => b.Dosis)
                    .HasForeignKey(b => b.RecetaRef);
            #endregion


        }

    }
}
