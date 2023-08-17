using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.core.Entities.Models
{
    [Table("Dosis")]
    public class Dosis : ModelBase
    {
        [Column("MedicamentoRef")]
        public string MedicamentoRef { get; set; }

        [Column("RecetaRef")]
        [ForeignKey("Receta")]
        public int RecetaRef { get; set; }
        public Receta Receta { get; set; }
    }
}