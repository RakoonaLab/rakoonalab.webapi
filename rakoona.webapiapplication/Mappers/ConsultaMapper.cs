using rakoona.dtos.Request.Consultas;
using rakoona.dtos.Response;
using rakoona.webapiapplication.Entities.Models.Consultas;

namespace rakoona.webapiapplication.Mappers
{
    public static class ConsultaMapper
    {
        public static ConsultaBase CreateFromRequest(this CreateConsultaRequest request, int mascotaId)
        {
            ConsultaBase Consulta = new ConsultaBase
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                Fecha = request.Fecha,
                Pulso = request.Pulso,
                CaracteristicasDelPulso = request.CaracteristicasDelPulso,
                FrecuenciaRespiratoria = request.FrecuenciaRespiratoria,
                Peso = request.Peso,
                RitmoCardiaco = request.RitmoCardiaco,
                Temperatura = request.Temperatura,
                Motivo = request.Motivo,
                Diagnostico = request.Diagnostico,
                Observaciones = request.Observaciones,
                MascotaRef = mascotaId
            };
            return Consulta;
        }

        public static ConsultaBase UpdateFromRequest(this UpdateConsultaRequest request, ConsultaBase consulta)
        {
            consulta.Fecha = request.Fecha;
            consulta.Pulso = request.Pulso;
            consulta.CaracteristicasDelPulso = request.CaracteristicasDelPulso;
            consulta.FrecuenciaRespiratoria = request.FrecuenciaRespiratoria;
            consulta.Peso = request.Peso;
            consulta.RitmoCardiaco = request.RitmoCardiaco;
            consulta.Temperatura = request.Temperatura;
            consulta.Motivo = request.Motivo;
            consulta.Diagnostico = request.Diagnostico;
            consulta.Observaciones = request.Observaciones;

            return consulta;
        }

        public static ConsultaResponse MapToResponse(this ConsultaBase entity)
        {
            ConsultaResponse response = new ConsultaResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                Fecha = entity.Fecha,
                Pulso = entity.Pulso,
                CaracteristicasDelPulso = entity.CaracteristicasDelPulso,
                FrecuenciaRespiratoria = entity.FrecuenciaRespiratoria,
                Peso = entity.Peso,
                RitmoCardiaco = entity.RitmoCardiaco,
                Temperatura = entity.Temperatura,
                Motivo = entity.Motivo,
                Diagnostico = entity.Diagnostico,
                Observaciones = entity.Observaciones,
            };
            return response;
        }
    }
}
