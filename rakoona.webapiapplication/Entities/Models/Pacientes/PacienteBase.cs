using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapiapplication.Entities.Models.Pacientes
{
    public class PacienteBase : ModelBase
    {
        public string Nombre { get; set; }
        public string? Genero { get; set; }

        public int? DiaNacimiento { get; set; }
        public int? MesNacimiento { get; set; }
        public int? AnioNacimiento { get; set; }
    }
}
