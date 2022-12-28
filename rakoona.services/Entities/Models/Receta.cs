using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Models
{
    public class Receta : ModelBase
    {
        public int ConsultaRef { get; set; }

        public List<Dosis> Dosis { get; set; }
    }
}