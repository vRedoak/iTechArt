using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Models
{
    public  class Asset
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(64)"),Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
