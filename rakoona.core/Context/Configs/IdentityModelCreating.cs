using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Maps.Seguridad;

namespace rakoona.core.Context.Configs
{
    internal class IdentityModelCreating
    {
        internal static void Config(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>(entity =>
            {
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {

            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {

            });

            builder.ApplyConfiguration(new UserMap());
        }
    }
}
