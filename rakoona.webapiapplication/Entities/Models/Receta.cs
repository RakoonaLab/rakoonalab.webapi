using rakoona.webapiapplication.Entities.Models.Consultas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapiapplication.Entities.Models
{
    [Table("Recetas")]
    public class Receta : ModelBase
    {
        [Column("ConsultaRef")]
        [ForeignKey("Consulta")]
        public int ConsultaRef { get; set; }
        public ConsultaBase Consulta { get; set; }

        [ForeignKey("RecetaRef")]
        public List<Dosis> Dosis { get; set; }
    }
}