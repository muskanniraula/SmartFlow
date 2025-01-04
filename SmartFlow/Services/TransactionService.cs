using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using SmartFlow.Models;

namespace SmartFlow.Services
{
    //public class TransactionService
    //{
    //    private string filePath = Path.Combine(FileSystem.AppDataDirectory, "transactions.json");

    //    public void AddTransaction(Transaction transaction)
    //    {
    //        var transactions = GetTransactions();
    //        transactions.Add(transaction);
    //        SaveTransactions(transactions);
    //    }

    //    public List<Transaction> GetTransactions()
    //    {
    //        if (File.Exists(filePath))
    //        {
    //            var json = File.ReadAllText(filePath);
    //            return JsonConvert.DeserializeObject<List<Transaction>>(json) ?? new List<Transaction>();
    //        }
    //        return new List<Transaction>();
    //    }

    //    public void SaveTransactions(List<Transaction> transactions)
    //    {
    //        var json = JsonConvert.SerializeObject(transactions);
    //        File.WriteAllText(filePath, json);
    //    }
    //}
}
