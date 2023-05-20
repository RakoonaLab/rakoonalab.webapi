using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.Consultas;
using rakoona.services.Entities.Models.Consultas.Mediciones;

namespace rakoona.services.Entities.Mappers
{
    public static class ConsultaMapper
    {
        public static Consulta CreateFromRequest(this CreateConsultaRequest request, int mascotaId, int medicoId)
        {
            if (request == null)
                throw new Exception("");

            var creacion = DateTime.Now;
            var aplicacion = DateTime.Parse(request.Fecha);


            Consulta consulta = new Consulta
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = creacion,
                FechaAplicacion = aplicacion,
                Motivo = request.Motivo,
                Diagnostico = request.Diagnostico,
                Observaciones = request.Observaciones,
                MascotaRef = mascotaId,
                MedicoRef = medicoId
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

            return consulta;
        }

        public static Consulta UpdateFromRequest(this UpdateConsultaRequest request, Consulta consulta)
        {
            var aplicacion = request.Fecha;

            consulta.FechaAplicacion = aplicacion;
            consulta.Motivo = request.Motivo;
            consulta.Diagnostico = request.Diagnostico;
            consulta.Observaciones = request.Observaciones;

            if (request.Pulso.HasValue)
            {
                if (consulta.Pulso != null)
                {
                    consulta.Pulso.Valor = request.Pulso.Value;
                    consulta.Pulso.FechaAplicacion = aplicacion;
                }
                else
                {
                    consulta.Pulso = new Pulso
                    {
                        ExternalId = Guid.NewGuid().ToString(),
                        Valor = request.Pulso.Value,
                        FechaDeCreacion = consulta.FechaDeCreacion,
                        FechaAplicacion = aplicacion,
                        MascotaRef = consulta.MascotaRef
                    };
                }

            }
            if (request.FrecuenciaRespiratoria.HasValue)
            {
                if (consulta.FrecuenciaRespiratoria != null)
                {
                    consulta.FrecuenciaRespiratoria.Valor = request.FrecuenciaRespiratoria.Value;
                    consulta.FrecuenciaRespiratoria.FechaAplicacion = aplicacion;
                }
                else
                {
                    consulta.FrecuenciaRespiratoria = new FrecuenciaRespiratoria
                    {
                        ExternalId = Guid.NewGuid().ToString(),
                        Valor = request.FrecuenciaRespiratoria.Value,
                        FechaDeCreacion = consulta.FechaDeCreacion,
                        FechaAplicacion = aplicacion,
                        MascotaRef = consulta.MascotaRef
                    };
                }
            }
            if (request.Peso.HasValue)
            {
                if (consulta.Peso != null)
                {
                    consulta.Peso.Valor = request.Peso.Value;
                    consulta.Peso.FechaAplicacion = aplicacion;
                }
                else
                {
                    consulta.Peso = new Peso
                    {
                        ExternalId = Guid.NewGuid().ToString(),
                        Valor = request.Peso.Value,
                        FechaDeCreacion = consulta.FechaDeCreacion,
                        FechaAplicacion = aplicacion,
                        MascotaRef = consulta.MascotaRef
                    };
                }
            }
            if (request.RitmoCardiaco.HasValue)
            {
                if (consulta.RitmoCardiaco != null)
                {
                    consulta.RitmoCardiaco.Valor = request.RitmoCardiaco.Value;
                    consulta.RitmoCardiaco.FechaAplicacion = aplicacion;
                }
                else
                {
                    consulta.RitmoCardiaco = new RitmoCardiaco
                    {
                        ExternalId = Guid.NewGuid().ToString(),
                        Valor = request.RitmoCardiaco.Value,
                        FechaDeCreacion = consulta.FechaDeCreacion,
                        FechaAplicacion = aplicacion,
                        MascotaRef = consulta.MascotaRef
                    };
                }
            }
            if (request.Temperatura.HasValue)
            {
                if (consulta.Temperatura != null)
                {
                    consulta.Temperatura.Valor = request.Temperatura.Value;
                    consulta.Temperatura.FechaAplicacion = aplicacion;
                }
                else
                {
                    consulta.Temperatura = new Temperatura
                    {
                        ExternalId = Guid.NewGuid().ToString(),
                        Valor = request.Temperatura.Value,
                        FechaDeCreacion = consulta.FechaDeCreacion,
                        FechaAplicacion = aplicacion,
                        MascotaRef = consulta.MascotaRef
                    };
                }
            }


            return consulta;
        }

        public static ConsultaResponse MapToResponse(this Consulta entity)
        {
            ConsultaResponse response = new()
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion.Date.ToShortDateString(),
                Fecha = entity.FechaAplicacion.Date.ToShortDateString(),
                Motivo = entity.Motivo,
                Diagnostico = entity.Diagnostico,
                Observaciones = entity.Observaciones,
                MascotaNombre = entity.Mascota?.Nombre,
                MascotaId = entity.Mascota?.ExternalId,
                ClienteNombre = entity.Mascota?.Duenio?.GetNombreCompleto(),
                ClienteId = entity.Mascota?.Duenio?.ExternalId,
            };


            if (entity.Pulso != null)
            {
                response.Pulso = entity.Pulso?.Valor.Value;
            }
            if (entity.FrecuenciaRespiratoria != null)
            {
                response.FrecuenciaRespiratoria = entity.FrecuenciaRespiratoria?.Valor.Value;
            }
            if (entity.Peso != null)
            {
                response.Peso = entity.Peso?.Valor.Value;
            }
            if (entity.RitmoCardiaco != null)
            {
                response.RitmoCardiaco = entity.RitmoCardiaco?.Valor.Value;
            }
            if (entity.Temperatura != null)
            {
                response.Temperatura = entity.Temperatura?.Valor.Value;
            }
            
            return response;
        }

        public static ConsultaResponse MapToConsultaResponse(this Consulta entity)
        {
            ConsultaResponse response = new()
            {
                Id = entity.ExternalId,
                Tipo = "Basica",
                FechaDeCreacion = entity.FechaDeCreacion.Date.ToShortDateString(),
                Fecha = entity.FechaAplicacion.Date.ToShortDateString(),
                Motivo = entity.Motivo,
                Diagnostico = entity.Diagnostico,
                Observaciones = entity.Observaciones,
                MascotaNombre = entity.Mascota?.Nombre,
                MascotaId = entity.Mascota?.ExternalId,
                ClienteNombre = entity.Mascota?.Duenio?.GetNombreCompleto(),
                ClienteId = entity.Mascota?.Duenio?.ExternalId,
            };

            if (entity.Pulso != null)
            {
                response.Pulso = entity.Pulso?.Valor.Value;
            }
            if (entity.FrecuenciaRespiratoria != null)
            {
                response.FrecuenciaRespiratoria = entity.FrecuenciaRespiratoria?.Valor.Value;
            }
            if (entity.Peso != null)
            {
                response.Peso = entity.Peso?.Valor.Value;
            }
            if (entity.RitmoCardiaco != null)
            {
                response.RitmoCardiaco = entity.RitmoCardiaco?.Valor.Value;
            }
            if (entity.Temperatura != null)
            {
                response.Temperatura = entity.Temperatura?.Valor.Value;
            }

            return response;
        }
    }
}
