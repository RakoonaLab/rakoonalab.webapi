using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
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
                Nombres = request.PrimerNombre + " " + request.SegundoNombre,
                Apellidos = request.PrimerApellido + " " + request.SegundoApellido,
                FechaDeNacimiento = request.Nacimiento != "" ? DateTime.Parse(request.Nacimiento) : null,

                ClinicaMedicos = new List<ClinicaMedico> { clinicaMedico }
            };
            return medico;
        }

        public static MedicoResponse MapToResponse(this Medico entity)
        {
            MedicoResponse response = new MedicoResponse
            {
                Id = entity.ExternalId,
                PrimerNombre = "",
                SegundoNombre = "",
                PrimerApellido = "",
                SegundoApellido = "",
                Nacimiento = "",
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
