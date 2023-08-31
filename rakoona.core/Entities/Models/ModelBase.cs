using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rakoona.core.Entities.Models
{
    public class ModelBase
    {
        private string _id;

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ExternalId")]
        public string ExternalId
        {
            get
            {
                if (String.IsNullOrEmpty(_id))
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
