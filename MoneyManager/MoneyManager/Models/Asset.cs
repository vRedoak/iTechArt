using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager
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
