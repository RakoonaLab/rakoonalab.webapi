using rakoona.core.Entities.Models.Seguridad;
using rakoona.dtos.Response;
using System.Text;

namespace rakoona.core.Entities.Mappers
{
    internal static class PlanMapper
    {
        internal static PlanResponse MapToResponse(this Plan entity)
        {
            PlanResponse response = new PlanResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                Nombre = entity.Nombre,
                NumeroDeClinicas = entity.NumeroDeClinicas,
                NumeroDeMedicos = entity.NumeroDeMedicos
            };

            if (entity.Precios.Count() > 0)
            {
                var precio = entity.Precios.FirstOrDefault();

                response.Valor = precio != null ? precio.Valor : 0;
                response.PrecioRef = precio != null ? precio.ExternalId : "";
            }

            return response;
        }
    }
}
