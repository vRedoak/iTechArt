using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Models
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int ParentId { get; set; }
        public Category Category { get; set; }
    }
}
