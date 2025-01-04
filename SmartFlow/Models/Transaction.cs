using System;

namespace SmartFlow.Models
{
    public class Transaction
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }  // Credit, Debit, Debt
        public string Category { get; set; }
        public List<string> Tags { get; set; }
        public string Notes { get; set; }
    }
}
