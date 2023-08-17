using Microsoft.EntityFrameworkCore;
using rakoona.services.Entities.Models.Pacientes;

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
                    Genero = GeneroDBInitializer.Felis,
                    ClaseAnimal = ClaseAnimalDBInitializer.Mamiferos,
                    Orden = OrdenAnimalDBInitializer.Carnivoro,
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
                    Genero = GeneroDBInitializer.Canis,
                    Orden = OrdenAnimalDBInitializer.Carnivoro,
                    ClaseAnimal = ClaseAnimalDBInitializer.Mamiferos,
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
                    Genero = GeneroDBInitializer.Mustela,
                    Orden = OrdenAnimalDBInitializer.Carnivoro,
                    ClaseAnimal = ClaseAnimalDBInitializer.Mamiferos,
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
