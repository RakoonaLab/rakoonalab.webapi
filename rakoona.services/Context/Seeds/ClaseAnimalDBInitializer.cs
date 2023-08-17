using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Context.Seeds
{
    public static class ClaseAnimalDBInitializer
    {
        public static ClaseDeAnimales Mamiferos { get { return new ClaseDeAnimales { ExternalId = Guid.NewGuid().ToString(), Nombre = "Mamiforo" }; } }

        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<ClaseDeAnimales>().HasData(Mamiferos);
        }
    }
}
