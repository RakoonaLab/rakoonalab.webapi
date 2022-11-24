using rakoona.webapi.Entities.Models;
using rakoona.webapiapplication.Entities.Models.Seguridad;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.webapiapplication.Entities.Models
{
    [Table("Clinicas")]
    public class Clinica : ModelBase
    {
        [Column("UserRef")]
        [ForeignKey("Usuario")]
        public string UserRef { get; set; }
        public virtual User Usuario { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        public ICollection<ClinicaMedico> ClinicaMedicos { get; set; }
        public ICollection<ClienteClinica> ClienteClinicas { get; set; }

    }
}
