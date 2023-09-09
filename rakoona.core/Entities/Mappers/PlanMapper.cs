using rakoona.core.Entities.Models.Seguridad;
using rakoona.dtos.Response;
using System.Text;

namespace rakoona.core.Entities.Mappers
{
    internal static class PlanMapper
    {
        internal static PlanResponse MapToResponse(this Plan entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();


            PlanResponse response = new PlanResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                Nombre = entity.Nombre,
                Valor = entity.Precios.FirstOrDefault().Valor,
                PrecioRef = entity.Precios.FirstOrDefault().ExternalId
            };

            return response;
        }
    }
}
