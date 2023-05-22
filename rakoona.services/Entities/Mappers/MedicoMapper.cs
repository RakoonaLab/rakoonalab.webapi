using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Personas;
using rakoona.services.Entities.Models.TiposDeContacto;

namespace rakoona.services.Entities.Mappers
{
    internal static class MedicoMapper
    {
        internal static Medico CreateFromRequest(this CreateMedicoRequest request, int clinicaId)
        {
            ClinicaMedico clinicaMedico = new ClinicaMedico
            {
                ClinicaId = clinicaId
            };

            PersonaBase persona = new PersonaBase
            {
                ExternalId = Guid.NewGuid().ToString(),
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
            };

            if (!string.IsNullOrEmpty(request.Celular))
            {
                persona.InformacionDeContacto = new List<Contacto> {
                    new Celular { ExternalId = Guid.NewGuid().ToString(), Valor = request.Celular }
                };
            }

            Medico medico = new Medico
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                PersonaInfo = persona,
                ClinicaMedicos = new List<ClinicaMedico> { clinicaMedico }
            };

            return medico;
        }

        internal static MedicoResponse MapToResponse(this Medico entity)
        {
            var celular = entity.PersonaInfo?.InformacionDeContacto?.FirstOrDefault(x => x.ContactType == "Celular")?.Valor;

            MedicoResponse response = new MedicoResponse
            {
                Id = entity.ExternalId,
                Nombres = entity.PersonaInfo?.Nombres,
                Apellidos = entity.PersonaInfo?.Apellidos,
                Celular = celular,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
