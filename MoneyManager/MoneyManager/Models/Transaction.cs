using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace MoneyManager
{
    public class Transaction
    {
        [XmlIgnore]
        public int Id { get; set; }
        
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Column(TypeName = "nvarchar(64)"), Required]
        public decimal Amount { get; set; }

        [Required]
        public int AssetId { get; set; }

        public Asset Asset { get; set; }

        [Column(TypeName = "nvarchar(1024)")]
        public string Comment { get; set; }
    }
}
