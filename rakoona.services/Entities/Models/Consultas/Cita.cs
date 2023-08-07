using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Models.Consultas
{
    public class Cita : ModelBase
    {
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }
        public int MascotaRef { get; set; }
        public virtual Mascota? Mascota { get; set; }
    }
}
