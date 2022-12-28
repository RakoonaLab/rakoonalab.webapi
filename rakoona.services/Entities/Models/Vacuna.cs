using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Models
{
    public class Vacuna : ModelBase
    {
        public string Nombre { get; set; }
        public string Lote { get; set; }
        public string Laboratorio { get; set; }
        public DateOnly Caducidad { get; set; }

        public int ConsultaRef { get; set; }
        public virtual ConsultaPreventiva ConsultaPreventiva { get; set; }
    }
}
