using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Mappers
{
    public static class ConsultaBasicaMapper
    {
        public static Consulta CreateFromRequest(this CreateConsultaBasicaRequest request, int mascotaId)
        {
            Consulta Consulta = new Consulta
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

        public static Consulta UpdateFromRequest(this UpdateConsultaRequest request, Consulta consulta)
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

        public static ConsultaBasicaResponse MapToResponse(this Consulta entity)
        {
            ConsultaBasicaResponse response = new ConsultaBasicaResponse
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
                ClienteNombre = entity.Mascota?.Duenio?.GetNombreCompleto(),
                ClienteId = entity.Mascota?.Duenio?.ExternalId,
            };
            return response;
        }

        public static ConsultaResponse MapToConsultaResponse(this Consulta entity)
        {
            ConsultaResponse response = new ()
            {
                Id = entity.ExternalId,
                Tipo="Basica",
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
                ClienteNombre = entity.Mascota?.Duenio?.GetNombreCompleto(),
                ClienteId = entity.Mascota?.Duenio?.ExternalId,
            };
            return response;
        }
    }
}
