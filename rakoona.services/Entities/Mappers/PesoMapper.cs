﻿using rakoona.services.Entities.Models.Consultas.Mediciones;

namespace rakoona.services.Entities.Mappers
{
    internal static class PesoMapper
    {
        internal static MedicionDePeso CreateFromRequest(double valor, int mascotaId, DateTime aplicacion, DateTime creacion)
        {
            MedicionDePeso pulso = new()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = creacion,
                FechaAplicacion = aplicacion,
                Valor = valor,
                MascotaRef = mascotaId,
            };
            return pulso;
        }
    }
}
