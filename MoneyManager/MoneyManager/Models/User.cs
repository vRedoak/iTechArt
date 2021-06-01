using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager
{
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(64)"), Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(64)"), Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(1024)"), Required]
        public string Hash { get; set; }

        [Column(TypeName = "nvarchar(64)"), Required]
        public string Salt { get; set; }

        public List<Asset> Asset { get; set; }
    }
}
