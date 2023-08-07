using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.Consultas;
using System.Text;

namespace rakoona.services.Entities.Mappers
{
    internal static class CitaMapper
    {
        internal static Cita CreateFromRequest(this CreateCitaRequest request, int mascotaId)
        {
            if (request == null)
                throw new Exception("");

            var creacion = DateTime.Now;
            var aplicacion = DateTime.Parse(request.Fecha);

            Cita cita = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = creacion,
                Fecha = aplicacion,
                MascotaRef = mascotaId,
                Comentarios = request.Comentarios,
            };

            return cita;
        }

        internal static CitaResponse MapToResponse(this Cita entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();


            CitaResponse response = new CitaResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                Fecha = entity.Fecha.ToShortDateString(),
                MascotaId = entity.Mascota?.ExternalId,
                MascotaNombre = entity.Mascota?.Nombre,
                DuenioId = entity.Mascota?.Duenio?.ExternalId,
                DuenioNombre = entity.Mascota?.Duenio?.Nombres + " " + entity.Mascota?.Duenio?.Apellidos,
            };

            return response;
        }
    }
}
