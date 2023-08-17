using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.core.Entities.Models.TiposDeContacto;

namespace rakoona.core.Entities.Maps.TiposDeContacto
{
    public class ContactoMap : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.ToTable(name: "InformacionDeContacto");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.ContactType).HasColumnName("ContactType").HasMaxLength(250);
            builder.Property(c => c.Valor).HasColumnName("Valor").HasMaxLength(250);

            #endregion

            #region Discriminator
            builder.HasDiscriminator(c => c.ContactType)
                .HasValue<Email>("Email")
                .HasValue<Celular>("Celular");
            #endregion

            #region HasOne

            builder.HasOne(a => a.Persona)
                    .WithMany(b => b.InformacionDeContacto)
                    .HasForeignKey(b => b.PersonaRef);

            #endregion
        }

    }
}
