using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Config.Helpers;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Consultas;
using System.Text;

namespace rakoona.services.Entities.Mappers
{
    public static class VacunaMapper
    {
        public static Vacunacion CreateFromRequest(this CreateVacunaRequest request, int mascotaId)
        {
            if (request == null)
                throw new Exception("");

            var now = DateTime.Now;
            Consulta consulta = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                MascotaRef = mascotaId,
                FechaDeCreacion = now,
                Fecha = now,
                Observaciones = request.Observaciones,
            };

            if (request.Peso.HasValue)
                consulta.Peso = request.Peso.Value;

            if (request.Temperatura.HasValue)
                consulta.Temperatura = request.Temperatura.Value;

            Vacunacion vacuna = new ()
            {
                Consulta = consulta,
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = now,
                Fecha = now,
                Nombre = request.Nombre,
                Lote = request.Lote,
                Laboratorio = request.Laboratorio
            };

            if (!string.IsNullOrEmpty(request.Caducidad))
                vacuna.Caducidad = DateTime.Parse(request.Caducidad);

            return vacuna;
        }

        public static VacunaResponse MapToResponse(this Vacunacion entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();


            VacunaResponse response = new VacunaResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion,
                FechaDeAplicacion = entity.Fecha.ToShortDateString(),
                Laboratorio = entity.Laboratorio,
                Caducidad = entity.Caducidad.Value.ToShortDateString(),
                Lote = entity.Lote,
                Peso = entity.Consulta?.Peso ?? 0,
                Temperatura = entity.Consulta?.Temperatura ?? 0,
                Observaciones = entity.Consulta?.Observaciones
            };
            return response;
        }

    }
}
