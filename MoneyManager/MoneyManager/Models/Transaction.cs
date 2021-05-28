using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager
{
    public class Transaction
    {
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
