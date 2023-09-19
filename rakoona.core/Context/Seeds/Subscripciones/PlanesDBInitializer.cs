using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Seguridad;

namespace rakoona.core.Context.Seeds
{
    public static class PlanesDBInitializer
    {
        public static Plan Free { get { return new Plan { Id = 1, FechaDeCreacion = DateTime.Now, ExternalId = Guid.NewGuid().ToString(), Nombre = "Free", NumeroDeClinicas = 1, NumeroDeMedicos = 1 }; } }
        public static Plan Basico { get { return new Plan { Id = 2, FechaDeCreacion = DateTime.Now, ExternalId = Guid.NewGuid().ToString(), Nombre = "Basico", NumeroDeClinicas = 1, NumeroDeMedicos= 5 }; } }

        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<Plan>().HasData(Free, Basico);
        }
    }
}
