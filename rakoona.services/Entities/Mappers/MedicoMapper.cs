using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models;
using rakoona.services.Entities.Models.Personas;
using rakoona.services.Entities.Models.TiposDeContacto;

namespace rakoona.services.Entities.Mappers
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
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                

                ClinicaMedicos = new List<ClinicaMedico> { clinicaMedico }
            };

            if (request.Celular != "")
            {
                medico.InformacionDeContacto = new List<Contacto> {
                    new Celular { ExternalId = Guid.NewGuid().ToString(), Valor = request.Celular }
                };
            }

            return medico;
        }

        public static MedicoResponse MapToResponse(this Medico entity)
        {
            var celular = entity.InformacionDeContacto?.FirstOrDefault(x => x.ContactType == "Celular")?.Valor;

            MedicoResponse response = new MedicoResponse
            {
                Id = entity.ExternalId,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Celular = celular,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
