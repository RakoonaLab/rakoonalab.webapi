using rakoona.core.Entities.Models.Personas;

namespace rakoona.core.Entities.Models.Consultas
{
    public class Consulta : AplicacionBase
    {
        public Consulta() { }

        public string? Observaciones { get; set; }
        public string? Motivo { get; set; }
        public string? Diagnostico { get; set; }

        public int MedicoRef { get; set; }
        public virtual Medico? Medico { get; set; }

        public int CartillaRef { get; set; }
        public virtual Cartilla? Cartilla { get; set; }
    }
}
