using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Consultas.Mediciones;

namespace rakoona.services.Entities.Mappers
{
    internal static class ConsultaMapper
    {
        internal static Consulta CreateFromRequest(this CreateConsultaRequest request, int mascotaId, int medicoId)
        {
            if (request == null)
                throw new Exception("");

            var creacion = DateTime.Now;
            var aplicacion = DateTime.Parse(request.Fecha);

            return new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = creacion,
                FechaAplicacion = aplicacion,
                Motivo = request.Motivo,
                Diagnostico = request.Diagnostico,
                Observaciones = request.Observaciones,
                MascotaRef = mascotaId,
                MedicoRef = medicoId
            };
        }

        internal static Consulta UpdateFromRequest(this UpdateConsultaRequest request, Consulta consulta)
        {
            var aplicacion = request.Fecha;

            consulta.FechaAplicacion = aplicacion;
            consulta.Motivo = request.Motivo;
            consulta.Diagnostico = request.Diagnostico;
            consulta.Observaciones = request.Observaciones;

            return consulta;
        }

        public static ConsultaResponse MapToResponse(this Consulta consulta)
        {
            return new()
            {
                Id = consulta.ExternalId,
                FechaDeCreacion = consulta.FechaDeCreacion.Date.ToShortDateString(),
                Fecha = consulta.FechaAplicacion.Date.ToShortDateString(),
                Motivo = consulta.Motivo,
                Diagnostico = consulta.Diagnostico,
                Observaciones = consulta.Observaciones,
                MascotaNombre = consulta.Mascota?.Nombre,
                MascotaId = consulta.Mascota?.ExternalId,
                ClienteNombre = consulta.Mascota?.Duenio?.GetNombreCompleto(),
                ClienteId = consulta.Mascota?.Duenio?.ExternalId,
            };
        }
    }
}
