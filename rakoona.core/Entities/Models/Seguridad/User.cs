using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models.Seguridad
{
    public class User : IdentityUser
    {
        public virtual Persona Persona { get; set; }
        public virtual Organizacion Organizacion { get; set; }
        public virtual IEnumerable<Subscripcion> Subscripciones { get; set; }
    }

    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "AspNetUsers");

            #region Identity

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id").HasMaxLength(250);
            builder.Property(c => c.AccessFailedCount).HasColumnName("AccessFailedCount");
            builder.Property(c => c.ConcurrencyStamp).HasColumnName("ConcurrencyStamp").HasMaxLength(250);
            builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(250);
            builder.Property(c => c.EmailConfirmed).HasColumnName("EmailConfirmed");
            builder.Property(c => c.LockoutEnabled).HasColumnName("LockoutEnabled");
            builder.Property(c => c.LockoutEnd).HasColumnName("LockoutEnd");
            builder.Property(c => c.NormalizedEmail).HasColumnName("NormalizedEmail").HasMaxLength(250);
            builder.Property(c => c.NormalizedUserName).HasColumnName("NormalizedUserName").HasMaxLength(250);
            builder.Property(c => c.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(250);
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(250);
            builder.Property(c => c.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            builder.Property(c => c.SecurityStamp).HasColumnName("SecurityStamp");
            builder.Property(c => c.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            builder.Property(c => c.UserName).HasColumnName("UserName").HasMaxLength(250);

            #endregion

        }
    }
}
