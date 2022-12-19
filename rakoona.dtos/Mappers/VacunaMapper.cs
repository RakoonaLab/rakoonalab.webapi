using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.services.Entities.Models;
using System.Text;

namespace rakoona.services.Mappers
{
    public static class VacunaMapper
    {
        public static Vacuna CreateFromRequest(this CreateVacunaRequest request, int? mascotaId)
        {
            Vacuna vacuna = new Vacuna
            {
                Nombre = request.Nombre,
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                 MascotaRef = mascotaId.Value
            };


            return vacuna;
        }

        public static VacunaResponse MapToResponse(this Vacuna entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();


            VacunaResponse response = new VacunaResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }

    }
}
