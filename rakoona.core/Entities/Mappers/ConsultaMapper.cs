using rakoona.dtos.Request.Consultas;
using rakoona.dtos.Response;
using rakoona.core.Entities.Models.Consultas;

namespace rakoona.core.Entities.Mappers
{
    internal static class ConsultaMapper
    {
        internal static Consulta CreateFromRequest(this CreateConsultaRequest request, int cartillaId, int medicoId)
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
                CartillaRef = cartillaId,
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
                MascotaNombre = consulta.Cartilla.Mascota?.Nombre,
                MascotaId = consulta.Cartilla.Mascota?.ExternalId,
                ClienteNombre = consulta.Cartilla.Mascota?.Duenio?.GetNombreCompleto(),
                ClienteId = consulta.Cartilla.Mascota?.Duenio?.ExternalId,
            };
        }
    }
}
