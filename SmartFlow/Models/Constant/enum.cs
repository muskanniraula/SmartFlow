using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFlow.Models.Constant
{
    public enum TransactionType
    {
        None = 0,
        Inflows = 1,
        Outflows = 2
    }

    public enum TransactionSource
    {
        None = 0,
        Credit = 1,
        Gain = 2,
        Budget = 3,
        Debit = 4,
        Spending = 5,
        Expenses = 6,

    }

    public enum PreferredCurrency
    {
        NPR,
        USD,
        EUR,
        GBP,
        INR
    }

}
