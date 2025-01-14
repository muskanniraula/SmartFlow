//using Microsoft.AspNetCore.Components;
//using SmartFlow.Interface;
//using SmartFlow.Models;
//using SmartFlow.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SmartFlow.Pages
//{
//    public partial class Transaction
//    {
//        private List<Transaction> transactions;

//        [Inject]

//        public ITransactionService TransactionService { get; set; }

//        protected override async Task OnInitializedAsync()
//        {
//            transactions = await TransactionService.GetAllTransactions();
//        }

//        private async Task AddTransaction(Transaction newTransaction)
//        {
//            var success = await TransactionService.AddTransaction(newTransaction);
//            if (success)
//            {
//                transactions = await TransactionService.GetAllTransactions(); // Reload the transactions list
//            }
//            else
//            {
//                // Handle failure
//            }
//        }
//    }
//}
