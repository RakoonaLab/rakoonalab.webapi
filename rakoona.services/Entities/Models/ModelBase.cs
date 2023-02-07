using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.services.Entities.Models
{
    public class ModelBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ExternalId")]
        public string ExternalId
        {
            get
            {
                if (_id == "" || _id == string.Empty)
                {
                    _id = Guid.NewGuid().ToString();
                }
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [Column("FechaDeCreacion")]
        public DateTime FechaDeCreacion { get; set; }
    }
}
