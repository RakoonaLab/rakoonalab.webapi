using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Mappers
{
    public static class MedicoMapper
    {
        public static Medico CreateFromRequest(this CreateMedicoRequest request, int clinicaId)
        {
            ClinicaMedico clinicaMedico = new ClinicaMedico
            {
                ClinicaId = clinicaId
            };

            Medico medico = new Medico
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                PrimerNombre = request.PrimerNombre,
                SegundoNombre = request.SegundoNombre,
                PrimerApellido = request.PrimerApellido,
                SegundoApellido = request.SegundoApellido,

                Nacimiento = request.Nacimiento != "" ? DateTime.Parse(request.Nacimiento) : null,

                ClinicaMedicos = new List<ClinicaMedico> { clinicaMedico }
            };
            return medico;
        }

        public static MedicoResponse MapToResponse(this Medico entity)
        {
            MedicoResponse response = new MedicoResponse
            {
                Id = entity.ExternalId,
                PrimerNombre = entity.PrimerNombre,
                SegundoNombre = entity.SegundoNombre,
                PrimerApellido = entity.PrimerApellido,
                SegundoApellido = entity.SegundoApellido,
                Nacimiento = entity.Nacimiento.ToString(),
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
