using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Entities.Models;
using System.Text;

namespace rakoona.core.Entities.Mappers
{
    internal static class VacunaMapper
    {
        internal static PlanDeVacunacion CreateFromRequest(this CreateVacunaRequest request, int cartillaId, int medicoId)
        {
            if (request == null)
                throw new Exception("");

            var creacion = DateTime.Now;
            var aplicacion = DateTime.Parse(request.Fecha);

            PlanDeVacunacion vacuna = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = creacion,
                FechaAplicacion = aplicacion,
                Nombre = request.Nombre,
                Lote = request.Lote,
                Laboratorio = request.Laboratorio,
                CartillaRef = cartillaId,
                MedicoRef = medicoId
            };

            if (!string.IsNullOrEmpty(request.Caducidad))
                vacuna.Caducidad = DateTime.Parse(request.Caducidad);

            return vacuna;
        }

        internal static VacunaResponse MapToResponse(this PlanDeVacunacion entity)
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
                MedicoId = entity.Medico?.ExternalId,
                MedicoNombre = entity.Medico?.PersonaInfo?.Nombres + " " + entity.Medico?.PersonaInfo?.Apellidos,
                MascotaId = entity.Cartilla.Mascota?.ExternalId,
                MascotaNombre = entity.Cartilla.Mascota?.Nombre,
                DuenioId = entity.Cartilla.Mascota?.Duenio?.ExternalId,
                DuenioNombre = entity.Cartilla.Mascota?.Duenio?.Nombres + " " + entity.Cartilla.Mascota?.Duenio?.Apellidos,
            };

            return response;
        }

    }
}
