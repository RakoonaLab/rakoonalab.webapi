using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;

namespace rakoona.webapiapplication.Mappers
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
                Nombre = entity.PrimerNombre,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
