using Microsoft.EntityFrameworkCore;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.core.Context.Seeds
{
    public static class GeneroDBInitializer
    {
        public static GeneroAnimal Canis { get { return new GeneroAnimal { Familia = FamiliaDBInitializer.Canidos, ExternalId = Guid.NewGuid().ToString(), Nombre = "Canis" }; } }
        public static GeneroAnimal Felis { get { return new GeneroAnimal { Familia = FamiliaDBInitializer.Félidos, ExternalId = Guid.NewGuid().ToString(), Nombre = "Felis" }; } }
        public static GeneroAnimal Mustela { get { return new GeneroAnimal { Familia = FamiliaDBInitializer.Mustélidos, ExternalId = Guid.NewGuid().ToString(), Nombre = "Mustela" }; } }

        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<GeneroAnimal>().HasData(
                Canis,
                Felis,
                Mustela);
        }
    }
}
