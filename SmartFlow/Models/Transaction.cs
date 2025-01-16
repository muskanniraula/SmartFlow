using System;
using System.Collections.Generic;

namespace SmartFlow.Models
{
    public class Transaction
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } 
        public string Category { get; set; }
        public string Status { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }

    }
}
