using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(64)"), Required]
        public string Name { get; set; }

        [Column(TypeName = "int"), Required]
        public int Type { get; set; }

        [Column(TypeName = "int"), Required]
        public int Color { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        public List<Category> Categories { get; set; }
    }
}
