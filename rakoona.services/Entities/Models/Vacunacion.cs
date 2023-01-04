using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Models
{
    public class Vacunacion : ModelBase
    {
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string? Lote { get; set; }
        public string? Laboratorio { get; set; }
        public DateTime? Caducidad { get; set; }

        public int ConsultaRef { get; set; }
        public virtual Consulta? Consulta { get; set; }
    }
}
