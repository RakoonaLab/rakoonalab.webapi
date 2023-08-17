using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models
{
    public class PlanDeVacunacion : AplicacionBase
    {
        public string Nombre { get; set; }
        public string? Lote { get; set; }
        public string? Laboratorio { get; set; }
        public DateTime? Caducidad { get; set; }


        public int MedicoRef { get; set; }
        public virtual Medico? Medico { get; set; }

        public int CartillaRef { get; set; }
        public virtual Cartilla? Cartilla { get; set; }
    }
}
