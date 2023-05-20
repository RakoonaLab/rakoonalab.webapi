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
    public static class VacunaMapper
    {
        public static Vacunacion CreateFromRequest(this CreateVacunaRequest request, int mascotaId, Medico medico)
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

            if (request.Pulso.HasValue)
            {
                consulta.Pulso = new Pulso
                {
                    ExternalId = Guid.NewGuid().ToString(),
                    Valor = request.Pulso.Value,
                    FechaDeCreacion = creacion,
                    FechaAplicacion = aplicacion,
                    MascotaRef = mascotaId,
                };
            }
            if (request.FrecuenciaRespiratoria.HasValue)
            {
                consulta.FrecuenciaRespiratoria = new FrecuenciaRespiratoria
                {
                    ExternalId = Guid.NewGuid().ToString(),
                    Valor = request.FrecuenciaRespiratoria.Value,
                    FechaDeCreacion = creacion,
                    FechaAplicacion = aplicacion,
                    MascotaRef = mascotaId

                };
            }
            if (request.Peso.HasValue)
            {
                consulta.Peso = new Peso
                {
                    ExternalId = Guid.NewGuid().ToString(),
                    Valor = request.Peso.Value,
                    FechaDeCreacion = creacion,
                    FechaAplicacion = aplicacion,
                    MascotaRef = mascotaId

                };
            }
            if (request.RitmoCardiaco.HasValue)
            {
                consulta.RitmoCardiaco = new RitmoCardiaco
                {
                    ExternalId = Guid.NewGuid().ToString(),
                    Valor = request.RitmoCardiaco.Value,
                    FechaDeCreacion = creacion,
                    FechaAplicacion = aplicacion,
                    MascotaRef = mascotaId

                };
            }
            if (request.Temperatura.HasValue)
            {
                consulta.Temperatura = new Temperatura
                {
                    ExternalId = Guid.NewGuid().ToString(),
                    Valor = request.Temperatura.Value,
                    FechaDeCreacion = creacion,
                    FechaAplicacion = aplicacion,
                    MascotaRef = mascotaId

                };
            }

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

        public static VacunaResponse MapToResponse(this Vacunacion entity)
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
            if (entity.Caducidad.HasValue)
            {
                response.Caducidad = entity.Caducidad.Value.ToShortDateString();
            }
            if (entity.Consulta?.Peso != null )
            {
                response.Peso = entity.Consulta?.Peso?.Valor.Value;
            }
            if (entity.Consulta?.Temperatura != null)
            {
                response.Temperatura = entity.Consulta?.Temperatura?.Valor.Value;
            }
            if (entity.Consulta?.Pulso != null)
            {
                response.Pulso = entity.Consulta?.Pulso?.Valor.Value;
            }
            if (entity.Consulta?.RitmoCardiaco != null)
            {
                response.RitmoCardiaco = entity.Consulta?.RitmoCardiaco?.Valor.Value;
            }
            if (entity.Consulta?.FrecuenciaRespiratoria != null)
            {
                response.FrecuenciaRespiratoria = entity.Consulta?.FrecuenciaRespiratoria?.Valor.Value;
            }



            return response;
        }

    }
}
