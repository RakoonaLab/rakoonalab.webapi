using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Consultas.Mediciones
{
    public class MedicionDePulso : ModelBase
    {
        public DateTime FechaAplicacion { get; set; }
        public int Valor { get; set; }
        public string? Caracteristicas { get; set; }


        public int MascotaRef { get; set; }
        public Mascota? Mascota { get; set; }
        public Consulta? Consulta { get; set; }
    }
}
