// Models/Transaction.cs
using System;
using System.Collections.Generic;


// Models/Debt.cs
namespace SmartFlow.Models
{
    public class Debt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateOnly? ClearedDate { get; set; }

        public string Category { get; set; }
        public string Status { get; set; } = "Pending";  // Pending, Overdue, Cleared
        public string Type { get; set; }
    }
}
