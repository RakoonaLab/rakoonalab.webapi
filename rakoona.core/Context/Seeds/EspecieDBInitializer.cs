using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Context.Seeds
{
    public static class EspecieDBInitializer
    {
        public static Especie Gato
        {
            get
            {
                return new Especie
                {
                    Id = 1,
                    FechaDeCreacion = DateTime.Now,
                    GeneroRef = GeneroDBInitializer.Felis.Id,
                    ClaseAnimalRef = ClaseAnimalDBInitializer.Mamiferos.Id,
                    OrdenAnimalRef = OrdenAnimalDBInitializer.Carnivoro.Id,
                    ExternalId = Guid.NewGuid().ToString(),
                    NombreCorto = "Gato"
                };
            }
        }
        public static Especie Perro
        {
            get
            {
                return new Especie
                {
                    Id = 2,
                    FechaDeCreacion = DateTime.Now,
                    GeneroRef = GeneroDBInitializer.Canis.Id,
                    OrdenAnimalRef = OrdenAnimalDBInitializer.Carnivoro.Id,
                    ClaseAnimalRef = ClaseAnimalDBInitializer.Mamiferos.Id,
                    ExternalId = Guid.NewGuid().ToString(),
                    NombreCorto = "Perro"
                };
            }
        }
        public static Especie Huron
        {
            get
            {
                return new Especie
                {
                    Id = 3,
                    FechaDeCreacion = DateTime.Now,
                    GeneroRef = GeneroDBInitializer.Mustela.Id,
                    OrdenAnimalRef = OrdenAnimalDBInitializer.Carnivoro.Id,
                    ClaseAnimalRef = ClaseAnimalDBInitializer.Mamiferos.Id,
                    ExternalId = Guid.NewGuid().ToString(),
                    NombreCorto = "Hurón"
                };
            }
        }


        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<Especie>().HasData(Gato, Perro, Huron);
        }
    }
}
