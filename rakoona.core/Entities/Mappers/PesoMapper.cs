using rakoona.core.Entities.Models.Consultas.Mediciones;

namespace rakoona.core.Entities.Mappers
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
