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

            ConsultaBase Consulta = new ConsultaBase
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = now,
                Fecha = now,
                Pulso = request.Pulso,
                CaracteristicasDelPulso = request.CaracteristicasDelPulso,
                FrecuenciaRespiratoria = request.FrecuenciaRespiratoria,
                Peso = request.Peso,
                RitmoCardiaco = request.RitmoCardiaco,
                Temperatura = request.Temperatura,
                Motivo = "Vacuna",
                Observaciones = request.Observaciones,
                MascotaRef = mascotaId
            };

            Vacuna vacuna = new Vacuna
            {
                Nombre = request.Nombre,
                Lote = request.Lote,
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = now,
                Consulta = Consulta
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
