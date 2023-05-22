using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Consultas.Mediciones;
using rakoona.services.Entities.Models.Personas;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace rakoona.services.Entities.Mappers
{
    internal static class VacunaMapper
    {
        internal static Vacunacion CreateFromRequest(this CreateVacunaRequest request, int mascotaId, Medico medico)
        {
            if (request == null)
                throw new Exception("");

            var creacion = DateTime.Now;
            var aplicacion = DateTime.Parse(request.Fecha);

            Consulta consulta = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                MascotaRef = mascotaId,
                FechaDeCreacion = creacion,
                FechaAplicacion = aplicacion,
                Observaciones = request.Observaciones,
                Medico = medico
            };

            Vacunacion vacuna = new()
            {
                Consulta = consulta,
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = creacion,
                FechaDeAplicacion = aplicacion,
                Nombre = request.Nombre,
                Lote = request.Lote,
                Laboratorio = request.Laboratorio
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
                Fecha = entity.Consulta?.FechaAplicacion.ToShortDateString(),
                Laboratorio = entity.Laboratorio,
                Lote = entity.Lote,
                Observaciones = entity.Consulta?.Observaciones,
                Motivo = entity.Consulta?.Motivo,
                MedicoId= entity.Consulta?.Medico?.ExternalId,
                MedicoNombre = entity.Consulta?.Medico?.PersonaInfo?.Nombres + " " + entity.Consulta?.Medico?.PersonaInfo?.Apellidos,
                MascotaId = entity.Consulta?.Mascota?.ExternalId,
                MascotaNombre = entity.Consulta?.Mascota?.Nombre,
                DuenioId = entity.Consulta?.Mascota?.Duenio?.ExternalId,
                DuenioNombre = entity.Consulta?.Mascota?.Duenio? .Nombres + " " + entity.Consulta?.Mascota?.Duenio?.Apellidos,
            };
        
            return response;
        }

    }
}
