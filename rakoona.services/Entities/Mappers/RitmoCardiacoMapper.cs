﻿using rakoona.services.Entities.Models.Consultas.Mediciones;

namespace rakoona.services.Entities.Mappers
{
    internal static class RitmoCardiacoMapper
    {
        internal static MedicionDeRitmoCardiaco CreateFromRequest(int valor, int mascotaId, DateTime aplicacion, DateTime creacion)
        {
            MedicionDeRitmoCardiaco pulso = new()
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
