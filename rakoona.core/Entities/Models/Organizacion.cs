using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Seguridad;
using Azure.Identity;

namespace rakoona.core.Entities.Models
{
    public class Organizacion : ModelBase
    {
        public string UserRef { get; set; }
        public virtual User Usuario { get; set; }
        public virtual IEnumerable<Clinica> Clinicas { get; set; }
    }

    internal class OrganizacionMap : IEntityTypeConfiguration<Organizacion>
    {
        public void Configure(EntityTypeBuilder<Organizacion> builder)
        {
            builder.ToTable(name: "Organizaciones");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.UserRef).HasColumnName("UserRef").IsRequired(false);

            //TODO: la relacion deveria ser uno a uno sin admitir nulos. pero como ya hay informacion pues.....
            builder.HasOne(a => a.Usuario)
                    .WithOne(b => b.Organizacion)
                    .HasForeignKey<Organizacion>(b => b.UserRef)
                    .OnDelete(DeleteBehavior.NoAction);

            
        }

    }
}
