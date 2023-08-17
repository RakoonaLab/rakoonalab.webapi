using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Entities.Models;
using rakoona.core.Entities.Models.Personas;
using rakoona.core.Entities.Models.TiposDeContacto;

namespace rakoona.core.Entities.Mappers
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
