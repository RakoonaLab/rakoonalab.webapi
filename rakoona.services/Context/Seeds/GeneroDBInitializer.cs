using Microsoft.EntityFrameworkCore;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.core.Context.Seeds
{
    public static class GeneroDBInitializer
    {
        public static GeneroAnimal Canis { get { return new GeneroAnimal { Id = 1, FechaDeCreacion = DateTime.Now, FamiliaRef = FamiliaDBInitializer.Canidos.Id, ExternalId = Guid.NewGuid().ToString(), Nombre = "Canis" }; } }
        public static GeneroAnimal Felis { get { return new GeneroAnimal { Id = 2, FechaDeCreacion = DateTime.Now, FamiliaRef = FamiliaDBInitializer.Félidos.Id, ExternalId = Guid.NewGuid().ToString(), Nombre = "Felis" }; } }
        public static GeneroAnimal Mustela { get { return new GeneroAnimal { Id = 3, FechaDeCreacion = DateTime.Now, FamiliaRef = FamiliaDBInitializer.Mustélidos.Id, ExternalId = Guid.NewGuid().ToString(), Nombre = "Mustela" }; } }

        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<GeneroAnimal>().HasData(
                Canis,
                Felis,
                Mustela);
        }
    }
}
