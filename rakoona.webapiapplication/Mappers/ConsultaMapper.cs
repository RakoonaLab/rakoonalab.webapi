﻿using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Consultas;

namespace rakoona.webapiapplication.Mappers
{
    public static class ConsultaMapper
    {
        public static ConsultaBase CreateFromRequest(this CreateConsultaRequest request, int mascotaId)
        {
            ConsultaBase Consulta = new ConsultaBase
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                Diagnostico = "",
                Observaciones = "",
                MascotaRef = mascotaId
            };
            return Consulta;
        }

        public static ConsultaResponse MapToResponse(this ConsultaBase entity)
        {
            ConsultaResponse response = new ConsultaResponse
            {
                Id = entity.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }
    }
}
