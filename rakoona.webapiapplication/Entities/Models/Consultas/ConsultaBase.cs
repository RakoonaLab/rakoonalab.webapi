using rakoona.webapiapplication.Entities.Models.Pacientes;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapiapplication.Entities.Models.Consultas
{
    [Table("Consultas")]
    public class ConsultaBase : ModelBase
    {
        [Column("Fecha")]
        public DateTime Fecha { get; set; }
        public double? Peso { get; set; }
        public double? Temperatura { get; set; }
        public int? RitmoCardiaco { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public int? Pulso { get; set; }
        public string? CaracteristicasDelPulso { get; set; }
        public string? Motivo { get; set; }

        [Column("Observaciones")]
        public string? Observaciones { get; set; }

        [Column("Diagnostico")]
        public string? Diagnostico { get; set; }

        [Column("MascotaRef")]
        [ForeignKey("Mascota")]
        public int MascotaRef { get; set; }
        public virtual Mascota Mascota { get; set; }

        [ForeignKey("ConsultaRef")]
        public List<Receta> Recetas { get; set; }



    }
}

