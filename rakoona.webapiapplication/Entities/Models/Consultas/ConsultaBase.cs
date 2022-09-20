using rakoona.webapiapplication.Entities.Models.Pacientes;
using rakoona.webapiapplication.Entities.Models.Personas;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapiapplication.Entities.Models.Consultas
{
    [Table("Consultas")]
    public class ConsultaBase : ModelBase
    {
        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Column("Observaciones")]
        public string Observaciones { get; set; }
        
        [Column("Diagnostico")]
        public string Diagnostico { get; set; }

        [Column("MascotaRef")]
        [ForeignKey("Mascota")]
        public int MascotaRef { get; set; }
        public virtual Mascota Mascota { get; set; }

        [ForeignKey("ConsultaRef")]
        public List<Receta> Recetas { get; set; }

    }
}

