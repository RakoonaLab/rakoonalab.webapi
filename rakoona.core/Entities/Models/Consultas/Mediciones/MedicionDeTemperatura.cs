using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Consultas.Mediciones
{
    public class MedicionDeTemperatura : ModelBase
    {
        public DateTime FechaAplicacion { get; set; }
        public double Valor { get; set; }


        public int MascotaRef { get; set; }
        public Mascota? Mascota { get; set; }
        public Consulta? Consulta { get; set; }
    }
}
