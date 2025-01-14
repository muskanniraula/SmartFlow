using SmartFlow.Models;
using SmartFlow.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartFlow.Services
{
    public class DebtService : GenericService<Debt>, IDebtService
    {
        private readonly string AppDebtsFilePath = UtilityService.GetAppDebtsFilePath();
        private List<Debt> debts;

        public DebtService()
        {
            // Load debts from the file when the service is initialized
            debts = GetAll(AppDebtsFilePath) ?? new List<Debt>();
        }

        public List<Debt> GetAllDebts()
        {
            return debts;
        }

        /// <summary>
        /// Adds a new debt to the collection and saves it to the file.
        /// </summary>
        public async Task<bool> AddDebtAsync(Debt debt)
        {
            try
            {
                if (string.IsNullOrEmpty(debt.Name) || debt.Amount <= 0)
                {
                    throw new ArgumentException("Debt name and amount must be provided.");
                }

                // Generate unique ID based on the current debt count
                var newDebt = new Debt
                {
                    Id = debts.Count > 0 ? debts.Max(d => d.Id) + 1 : 1,  // Generate a unique ID
                    Name = debt.Name,
                    Source = debt.Source,
                    Amount = debt.Amount,
                    StartDate = debt.StartDate, // Use the provided start date
                    DueDate = debt.DueDate,
                    ClearedDate = debt.ClearedDate,
                    Category = debt.Category,
                    Status = debt.Status
                };

                debts.Add(newDebt);

                // Save all debts to the file after adding the new one
                await Task.Run(() => SaveAll(debts, AppDebtsFilePath));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding debt: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Marks a debt as cleared by updating its status and setting the cleared date.
        /// </summary>
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

                // Save the updated debts list
                await Task.Run(() => SaveAll(debts, AppDebtsFilePath));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing debt: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Saves all debts to the file.
        /// </summary>
        private void SaveAll(List<Debt> debts, string filePath)
        {
            try
            {
                var json = JsonSerializer.Serialize(debts);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving debts: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads all debts from the file.
        /// </summary>
        private List<Debt> GetAll(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>();
                }
                return new List<Debt>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading debts: {ex.Message}");
                return new List<Debt>();
            }
        }
    }
}
