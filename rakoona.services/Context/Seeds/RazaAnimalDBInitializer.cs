using Microsoft.EntityFrameworkCore;
using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.core.Context.Seeds
{
    public static class RazaAnimalDBInitializer
    {
        public static RazaAnimal Affenpinscher
        {
            get
            {
                return new RazaAnimal
                {
                    Id = 1,
                    FechaDeCreacion = DateTime.Now,
                    EspecieRef = EspecieDBInitializer.Perro.Id,
                    ExternalId = Guid.NewGuid().ToString(),
                    NombreColoquial = "Affenpinscher"
                };
            }
        }
        public static RazaAnimal Afgano
        {
            get
            {
                return new RazaAnimal
                {
                    Id = 2,
                    FechaDeCreacion = DateTime.Now,
                    EspecieRef = EspecieDBInitializer.Perro.Id,
                    ExternalId = Guid.NewGuid().ToString(),
                    NombreColoquial = "Afgano"
                };
            }
        }
        public static RazaAnimal Akita
        {
            get
            {
                return new RazaAnimal
                {
                    Id = 3,
                    FechaDeCreacion = DateTime.Now,
                    EspecieRef = EspecieDBInitializer.Perro.Id,
                    ExternalId = Guid.NewGuid().ToString(),
                    NombreColoquial = "Akita"
                };
            }
        }

        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<RazaAnimal>().HasData(Affenpinscher,
                Afgano,
                Akita
                );
        }
    }
}
