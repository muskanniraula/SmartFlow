using SmartFlow.Interface;
using SmartFlow.Models;
using SmartFlow.Services;

namespace SmartFlow.Services
{
    public class TransactionService : GenericService<Transaction>, ITransactionService
    {
        private List<Transaction> transactions;
        private readonly string AppTransactionsFilePath;

        public TransactionService()
        {
            AppTransactionsFilePath = UtilityService.GetAppTransactionsFilePath();
            transactions = GetAll(AppTransactionsFilePath) ?? new List<Transaction>();
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }

        public async Task<bool> AddTransaction(Transaction transaction)
        {
            try
            {
                if (string.IsNullOrEmpty(transaction.Name) || transaction.Amount <= 0)
                {
                    throw new ArgumentException("Transaction name and amount must be provided.");
                }

                var newTransaction = new Transaction
                {
                    Name = transaction.Name,
                    Amount = transaction.Amount,
                    Date = transaction.Date == default ? DateTime.Now : transaction.Date,
                    Category = transaction.Category,
                    Status = transaction.Status ?? "Completed",
                    Type = transaction.Type,
                    Tags = transaction.Tags,
                    Notes = transaction.Notes
                };

                transactions.Add(newTransaction);
                SaveAll(transactions, AppTransactionsFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding transaction: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateTransaction(Transaction updatedTransaction)
        {
            try
            {
                var existingTransaction = transactions.FirstOrDefault(t => t.Id == updatedTransaction.Id);
                if (existingTransaction == null) return false;

                existingTransaction.Name = updatedTransaction.Name;
                existingTransaction.Amount = updatedTransaction.Amount;
                existingTransaction.Date = updatedTransaction.Date;
                existingTransaction.Category = updatedTransaction.Category;
                existingTransaction.Status = updatedTransaction.Status;
                existingTransaction.Type = updatedTransaction.Type;
                existingTransaction.Tags = updatedTransaction.Tags;
                existingTransaction.Notes = updatedTransaction.Notes;

                SaveAll(transactions, AppTransactionsFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating transaction: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Transaction> FilterTransactions(string searchTitle, string selectedType, DateTime? startDate, DateTime? endDate)
        {
            return transactions.Where(t =>
                (string.IsNullOrEmpty(searchTitle) ||
                t.Name.Contains(searchTitle, StringComparison.OrdinalIgnoreCase) ||
                (!string.IsNullOrEmpty(t.Tags) && t.Tags.Contains(searchTitle, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrEmpty(selectedType) || t.Type.Equals(selectedType, StringComparison.OrdinalIgnoreCase)) &&
                (!startDate.HasValue || t.Date.Date >= startDate.Value.Date) &&
                (!endDate.HasValue || t.Date.Date <= endDate.Value.Date))
                .OrderByDescending(t => t.Date);
        }


        public List<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return transactions.Where(t => t.Date.Date >= startDate.Date && t.Date.Date <= endDate.Date)
                             .OrderByDescending(t => t.Date)
                             .ToList();
        }

        public List<Transaction> GetTopTransactions(string type, int count, bool highest = true)
        {
            var filtered = transactions.Where(t => t.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
            return highest
                ? filtered.OrderByDescending(t => t.Amount).Take(count).ToList()
                : filtered.OrderBy(t => t.Amount).Take(count).ToList();
        }
    }
}