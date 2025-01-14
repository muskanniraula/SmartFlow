using SmartFlow.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartFlow.Interface
{
    public interface ITransactionService
    {
        List<Transaction> GetAllTransactions();
        Task<bool> AddTransaction(Transaction transaction);
        Task<bool> UpdateTransaction(Transaction updatedTransaction);
        IEnumerable<Transaction> FilterTransactions(string searchTitle, string selectedType, DateTime? startDate, DateTime? endDate);
        List<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate);
        List<Transaction> GetTopTransactions(string type, int count, bool highest = true);
    }
}
