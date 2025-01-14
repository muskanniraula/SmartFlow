// Models/Transaction.cs
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
        public string Type { get; set; }  // Credit, Debit
        public string Category { get; set; }
        public string Status { get; set; }  // Completed, Failed, Pending
        public string Tags { get; set; }
        public string Notes { get; set; }

    }
}
