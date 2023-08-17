using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Entities.Models.Consultas.Mediciones
{
    public class MedicionDeFrecuenciaRespiratoria : ModelBase
    {
        public DateTime FechaAplicacion { get; set; }
        public int Valor { get; set; }


        public int MascotaRef { get; set; }
        public Mascota? Mascota { get; set; }
        public Consulta? Consulta { get; set; }
    }
}
