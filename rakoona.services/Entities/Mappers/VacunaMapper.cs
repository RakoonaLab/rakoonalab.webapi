using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Consultas;
using System.Text;

namespace rakoona.services.Entities.Mappers
{
    public static class VacunaMapper
    {
        public static Vacunacion CreateFromRequest(this CreateVacunaRequest request, int mascotaId)
        {
            var now = DateTime.Now;
            Vacunacion vacuna = new Vacunacion
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = now,
                Fecha = now,
                Nombre = request.Nombre,
                Lote = request.Lote,
                Caducidad = DateTime.Parse(request.Caducidad),
                Laboratorio = request.Laboratorio
            };


            return vacuna;
        }

        public static VacunaResponse MapToResponse(this Vacunacion entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();


            VacunaResponse response = new VacunaResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion,
                Laboratorio = entity.Laboratorio,
                Caducidad = entity.Caducidad,
            };
            return response;
        }

    }
}
