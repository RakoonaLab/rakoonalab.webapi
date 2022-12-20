using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Models
{
    public class Vacuna : ModelBase
    {
        public string Nombre { get; set; }
        public string? Lote { get; set; }
        public int ConsultaRef { get; set; }
        public virtual ConsultaBase Consulta { get; set; }
    }
}
