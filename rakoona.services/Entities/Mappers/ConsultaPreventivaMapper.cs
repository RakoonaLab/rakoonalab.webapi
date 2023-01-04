using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Mappers
{
    public static class ConsultaPreventivaMapper
    {
        public static ConsultaPreventiva CreateFromRequest(this CreateConsultaPreventivaRequest request, int mascotaId)
        {
            ConsultaPreventiva Consulta = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                Fecha = request.Fecha,
                Peso = request.Peso,
                Motivo = request.Motivo,
                Observaciones = request.Observaciones,
                MascotaRef = mascotaId
            };
            return Consulta;
        }

        public static ConsultaPreventiva UpdateFromRequest(this UpdateConsultaRequest request, ConsultaPreventiva consulta)
        {
            consulta.Fecha = request.Fecha;
            consulta.Peso = request.Peso;
            consulta.Motivo = request.Motivo;
            consulta.Observaciones = request.Observaciones;

            return consulta;
        }

        public static ConsultaPreventivaResponse MapToResponse(this ConsultaPreventiva entity)
        {
            ConsultaPreventivaResponse response = new()
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion.Date.ToShortDateString(),
                Fecha = entity.Fecha.Date.ToShortDateString(),
                Peso = entity.Peso.HasValue ? entity.Peso : 0,
                Motivo = entity.Motivo,
                Observaciones = entity.Observaciones,
                MascotaNombre = entity.Mascota?.Nombre,
                MascotaId = entity.Mascota?.ExternalId,
                ClienteNombre = entity.Mascota?.Duenio?.GetNombreCompleto(),
                ClienteId = entity.Mascota?.Duenio?.ExternalId,
            };
            return response;
        }

        public static ConsultaResponse MapToConsultaResponse(this ConsultaPreventiva entity)
        {
            ConsultaResponse response = new()
            {
                Id = entity.ExternalId,
                Tipo= "Preventiva",
                FechaDeCreacion = entity.FechaDeCreacion.Date.ToShortDateString(),
                Fecha = entity.Fecha.Date.ToShortDateString(),
                Peso = entity.Peso.HasValue ? entity.Peso : 0,
                Motivo = entity.Motivo,
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
