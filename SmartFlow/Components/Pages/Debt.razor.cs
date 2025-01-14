//using Microsoft.AspNetCore.Components;
//using SmartFlow.Models;
//using SmartFlow.Services;
//using System;
//using System.Collections.Generic;


//namespace SmartFlow.Pages
//{
//    public partial class Debt : ComponentBase
//    {
//        private List<Debt> debts = new();

//        protected override void OnInitialized()
//        {
//            try
//            {
//                debts = awaitDebtService.GetAllDebts(); // Ensure DebtService is accessible
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error fetching debts: {ex.Message}");
//            }
//        private List<Models.Debt> debts = new();

//        protected override void OnInitialized()
//        {
//            try
//            {
//                debts = DebtService.GetAllDebts();
//            }
//            catch (Exception ex)
//            {
//            }
//        }
//    }
//}
