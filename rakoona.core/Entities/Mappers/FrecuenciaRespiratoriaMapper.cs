using rakoona.core.Entities.Models.Consultas.Mediciones;

namespace rakoona.core.Entities.Mappers
{
    internal static class FrecuenciaRespiratoriaMapper
    {
        internal static MedicionDeFrecuenciaRespiratoria CreateFromRequest(int valor, int mascotaId, DateTime aplicacion, DateTime creacion)
        {
            MedicionDeFrecuenciaRespiratoria pulso = new()
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
