using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Consultas;
using System.Text;

namespace rakoona.services.Entities.Mappers
{
    public static class VacunaMapper
    {
        public static Vacuna CreateFromRequest(this CreateVacunaRequest request, int mascotaId)
        {
            var now = DateTime.Now;

            ConsultaPreventiva Consulta = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = now,
                Fecha = now,
                Peso = request.Peso,
                Motivo = "Vacuna",
                Observaciones = request.Observaciones,
                MascotaRef = mascotaId
            };

            Vacuna vacuna = new Vacuna
            {
                Nombre = request.Nombre,
                Lote = request.Lote,
                Caducidad = DateTime.Parse(request.Caducidad),
                Laboratorio = request.Laboratorio,
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = now,
                ConsultaPreventiva = Consulta
            };


            return vacuna;
        }

        public static VacunaResponse MapToResponse(this Vacuna entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();


            VacunaResponse response = new VacunaResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }

    }
}
