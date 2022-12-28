using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rakoona.services.Entities.Models.Consultas
{
    public class ConsultaPreventiva: ConsultaBase
    {
        public List<Vacuna> Vacunas { get; set; }
    }
}
