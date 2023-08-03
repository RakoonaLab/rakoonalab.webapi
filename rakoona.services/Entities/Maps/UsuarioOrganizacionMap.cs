using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    public class UsuarioOrganizacionMap : IEntityTypeConfiguration<UsuarioOrganizacion>
    {
        public void Configure(EntityTypeBuilder<UsuarioOrganizacion> builder)
        {
            builder.ToTable(name: "UsuarioOrganizacion");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            
            #endregion

            builder.HasOne(a => a.Organizacion)
                    .WithOne(b => b.UsuarioOrganizacion)
                    .HasForeignKey<UsuarioOrganizacion>(b => b.OrganizacionRef);

            builder.HasOne(a => a.Usuario)
                    .WithOne(b => b.UsuarioOrganizacion)
                    .HasForeignKey<UsuarioOrganizacion>(b => b.UserRef);
        }

    }
}