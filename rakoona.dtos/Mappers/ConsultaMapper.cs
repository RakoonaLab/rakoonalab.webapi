using rakoona.services.Dtos.Request.Consultas;
using rakoona.services.Dtos.Response;
using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Mappers
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
                FechaDeCreacion = entity.FechaDeCreacion.Date.ToShortDateString(),
                Fecha = entity.Fecha.Date.ToShortDateString(),
                Pulso = entity.Pulso.HasValue ? entity.Pulso : 0,
                CaracteristicasDelPulso = entity.CaracteristicasDelPulso,
                FrecuenciaRespiratoria = entity.FrecuenciaRespiratoria.HasValue ? entity.FrecuenciaRespiratoria : 0,
                Peso = entity.Peso.HasValue ? entity.Peso : 0,
                RitmoCardiaco = entity.RitmoCardiaco.HasValue ? entity.RitmoCardiaco : 0,
                Temperatura = entity.Temperatura.HasValue ? entity.Temperatura : 0,
                Motivo = entity.Motivo,
                Diagnostico = entity.Diagnostico,
                Observaciones = entity.Observaciones,
                MascotaNombre = entity.Mascota?.Nombre,
                MascotaId = entity.Mascota?.ExternalId,
                ClienteNombre = entity.Mascota?.Duenio?.NombreCompleto,
                ClienteId = entity.Mascota?.Duenio?.ExternalId,
            };
            return response;
        }
    }
}
