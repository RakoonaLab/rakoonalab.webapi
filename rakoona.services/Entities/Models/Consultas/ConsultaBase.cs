using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Models.Consultas
{
    public class ConsultaBase : ModelBase
    {
        public DateTime Fecha { get; set; }
        public double? Peso { get; set; }
        public string? Motivo { get; set; }

        public string? Observaciones { get; set; }

        public int MascotaRef { get; set; }
        public virtual Mascota Mascota { get; set; }
    }
}

