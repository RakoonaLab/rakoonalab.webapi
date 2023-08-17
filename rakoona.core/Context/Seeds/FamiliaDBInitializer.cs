using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Context.Seeds
{
    public static class FamiliaDBInitializer
    {
        public static Familia Canidos { get { return new Familia { Id = 1, FechaDeCreacion = DateTime.Now, ExternalId = Guid.NewGuid().ToString(), Nombre = "Canidos" }; } }
        public static Familia Félidos { get { return new Familia { Id = 2, FechaDeCreacion = DateTime.Now, ExternalId = Guid.NewGuid().ToString(), Nombre = "Félidos" }; } }
        public static Familia Mustélidos { get { return new Familia { Id = 3, FechaDeCreacion = DateTime.Now, ExternalId = Guid.NewGuid().ToString(), Nombre = "Mustélidos" }; } }


        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<Familia>().HasData(
                Canidos,
                Félidos,
                Mustélidos);
        }
    }
}
