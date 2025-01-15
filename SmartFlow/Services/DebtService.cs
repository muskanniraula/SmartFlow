using SmartFlow.Models;
using SmartFlow.Services;
using SmartFlow.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFlow.Services
{
    public class DebtService : GenericService<Debt>, IDebtService
    {
        private List<Debt> debts;
        private readonly string AppDebtsFilePath=UtilityService.GetAppDebtsFilePath();

        public DebtService()
        {


            // Load existing debts or initialize with an empty list
            debts = GetAll(AppDebtsFilePath) ?? new List<Debt>();
        }

        public List<Debt> GetAllDebts()
        {
            return debts;
        }

        public async Task<bool> AddDebtAsync(Debt debt)
        {
            try
            {
                if (string.IsNullOrEmpty(debt.Name) || debt.Amount <= 0)
                {
                    throw new ArgumentException("Debt name and amount must be provided.");
                }

                var newDebt = new Debt
                {
                    Id = debts.Any() ? debts.Max(d => d.Id) + 1 : 1, // Generate a unique ID
                    Name = debt.Name,
                    Source = debt.Source,
                    Amount = debt.Amount,
                    StartDate = DateTime.Now, // Automatically set StartDate
                    DueDate = debt.DueDate,
                    ClearedDate = debt.ClearedDate,
                    Category = debt.Category,
                    Status = debt.Status
                };

                debts.Add(newDebt);

                // Save debts to the file
                SaveAll(debts, AppDebtsFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding debt: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateDebt(Debt updatedDebt)
        {
            try
            {
                var existingDebt = debts.FirstOrDefault(d => d.Id == updatedDebt.Id);
                if (existingDebt == null) return false;

                existingDebt.Name = updatedDebt.Name;
                existingDebt.Amount = updatedDebt.Amount;
                existingDebt.StartDate = updatedDebt.StartDate;
                existingDebt.DueDate = updatedDebt.DueDate;
                existingDebt.ClearedDate = updatedDebt.ClearedDate;
                existingDebt.Status = updatedDebt.Status;
                existingDebt.Category = updatedDebt.Category;
                existingDebt.Source = updatedDebt.Source;

                // Save the updated list of debts
                SaveAll(debts, AppDebtsFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating debt: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ClearDebtAsync(int id)
        {
            try
            {
                var debt = debts.FirstOrDefault(d => d.Id == id);

                if (debt == null)
                {
                    return false;
                }

                debt.Status = "Cleared";
                debt.ClearedDate = DateOnly.FromDateTime(DateTime.Now);

                // Save the updated list of debts
                SaveAll(debts, AppDebtsFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing debt: {ex.Message}");
                return false;
            }
        }
    }
}
