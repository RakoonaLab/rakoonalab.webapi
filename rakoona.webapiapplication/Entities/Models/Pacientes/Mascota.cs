using rakoona.webapiapplication.Entities.Models.Consultas;
using rakoona.webapiapplication.Entities.Models.Personas;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapiapplication.Entities.Models.Pacientes
{
    [Table("Mascotas")]
    public class Mascota : PacienteBase
    {
        [Column("DuenioRef")]
        [ForeignKey("Duenio")]
        public int DuenioRef { get; set; }
        public virtual Owner Duenio { get; set; }

        [ForeignKey("MascotaRef")]
        public List<ConsultaBase> Consultas { get; set; }
    }
}
