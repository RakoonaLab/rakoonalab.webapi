using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Seguridad;

namespace rakoona.core.Context.Seeds
{
    public static class PreciosDBInitializer
    {
        public static Precio Free
        {
            get
            {
                return new Precio
                {
                    Id = 1,
                    FechaDeCreacion = DateTime.Now,
                    ExternalId = Guid.NewGuid().ToString(),
                    PlanRef = PlanesDBInitializer.Free.Id,
                    Tipo = TipoDeSubscripcion.None,
                    Valor = 0.0m,
                    ValidoDesde = DateTime.Now,

                };
            }
        }


        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<Precio>().HasData(Free);
        }
    }
}
