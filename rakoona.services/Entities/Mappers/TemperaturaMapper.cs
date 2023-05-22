using rakoona.services.Entities.Models.Consultas.Mediciones;

namespace rakoona.services.Entities.Mappers
{
    internal static class TemperaturaMapper
    {
        internal static MedicionDeTemperatura CreateFromRequest(double valor, int mascotaId, DateTime aplicacion, DateTime creacion)
        {
            MedicionDeTemperatura pulso = new()
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
