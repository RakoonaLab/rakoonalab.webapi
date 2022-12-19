using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Models
{
    public class Vacuna : ModelBase
    {
        public string Nombre { get; set; }
        public int MascotaRef { get; set; }
        public virtual Mascota Mascota { get; set; }
    }
}
