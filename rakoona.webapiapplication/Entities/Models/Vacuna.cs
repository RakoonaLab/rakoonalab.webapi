using rakoona.webapiapplication.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Pacientes;
using rakoona.webapiapplication.Entities.Models.Personas;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapi.Entities.Models
{
    [Table("Vacunas")]
    public class Vacuna : ModelBase
    {
        public string Nombre { get; set; }

        [Column("MascotaRef")]
        [ForeignKey("Mascota")]
        public int MascotaRef { get; set; }
        public virtual Mascota Mascota { get; set; }
    }
}
