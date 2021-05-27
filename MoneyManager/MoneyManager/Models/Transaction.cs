using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager
{
    class Transaction
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
       // public Category Category { get; set; }
        public decimal Amount { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string Comment { get; set; }
    }
}
