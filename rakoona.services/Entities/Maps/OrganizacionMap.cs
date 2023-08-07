using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    internal class OrganizacionMap : IEntityTypeConfiguration<Organizacion>
    {
        public void Configure(EntityTypeBuilder<Organizacion> builder)
        {
            builder.ToTable(name: "Organizaciones");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");


            #endregion

            #region Discriminator

            #endregion

            #region HasOne

            builder.HasOne(a => a.UsuarioOrganizacion)
                    .WithOne(b => b.Organizacion)
                    .HasForeignKey<UsuarioOrganizacion>(b => b.OrganizacionRef);

            #endregion
        }

    }
}