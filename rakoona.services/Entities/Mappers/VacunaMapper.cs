using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models;
using System.Text;

namespace rakoona.services.Entities.Mappers
{
    internal static class VacunaMapper
    {
        internal static Vacunacion CreateFromRequest(this CreateVacunaRequest request, int mascotaId, int medicoId)
        {
            if (request == null)
                throw new Exception("");

            var creacion = DateTime.Now;
            var aplicacion = DateTime.Parse(request.Fecha);

            Vacunacion vacuna = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = creacion,
                FechaAplicacion = aplicacion,
                Nombre = request.Nombre,
                Lote = request.Lote,
                Laboratorio = request.Laboratorio,
                MascotaRef = mascotaId,
                MedicoRef = medicoId
            };

            if (!string.IsNullOrEmpty(request.Caducidad))
                vacuna.Caducidad = DateTime.Parse(request.Caducidad);

            return vacuna;
        }

        internal static VacunaResponse MapToResponse(this Vacunacion entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();


            VacunaResponse response = new VacunaResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion,
                Fecha = entity.FechaAplicacion.ToShortDateString(),
                Laboratorio = entity.Laboratorio,
                Lote = entity.Lote,
                Caducidad = entity.Caducidad.Value.ToShortDateString(),
                MedicoId= entity.Medico?.ExternalId,
                MedicoNombre = entity.Medico?.PersonaInfo?.Nombres + " " + entity.Medico?.PersonaInfo?.Apellidos,
                MascotaId = entity.Mascota?.ExternalId,
                MascotaNombre = entity.Mascota?.Nombre,
                DuenioId = entity.Mascota?.Duenio?.ExternalId,
                DuenioNombre = entity.Mascota?.Duenio? .Nombres + " " + entity.Mascota?.Duenio?.Apellidos,
            };
        
            return response;
        }

    }
}
