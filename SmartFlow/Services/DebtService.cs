
using SmartFlow.Models;
using SmartFlow.Interface;
using SmartFlow.Services;
using SmartFlow.Services.Interface;

public class DebtService : GenericService<Debt>, IDebtService
{
    private readonly string AppDebtsFilePath = UtilityService.GetAppDebtsFilePath();

    /// <summary>
    /// Retrieves all debts from the file storage.
    /// </summary>
    /// <returns>A list of debts</returns>
    /// 
    private List<Debt> debts;

    public DebtService()
    {
        AppDebtsFilePath = UtilityService.GetAppDebtsFilePath();
        debts = GetAll(AppDebtsFilePath) ?? new List<Debt>();
    }

    public List<Debt> GetAllDebts()
    {
        return debts;
    }

    /// <summary>
    /// Adds a new debt to the collection and saves it to the file.
    /// </summary>
    /// <param name="debt">The debt to add</param>
    /// <returns>True if added successfully, otherwise false</returns>
    public async Task<bool> AddDebtAsync(Debt debt)
    {
        try
        {
            if (string.IsNullOrEmpty(debt.Name) || debt.Amount <= 0)
            {
                throw new ArgumentException("Debt name and amount must be provided.");
            }

            var debts = await Task.Run(() => GetAll(AppDebtsFilePath));

            var newDebt = new Debt
            {
                Id = 1, // Generate a unique ID
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

            await Task.Run(() => SaveAll(debts, AppDebtsFilePath)); // Simulate async file write
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
    /// <param name="debtId">The ID of the debt to clear</param>
    /// <returns>True if cleared successfully, otherwise false</returns>
    public async Task<bool> ClearDebtAsync(int Id)
    {
        try
        {
            var debts = await Task.Run(() => GetAll(AppDebtsFilePath));

            var debt = debts.FirstOrDefault(d => d.Id == Id);

            if (debt == null)
            {
                return false;
            }

            debt.Status = "Cleared";
            debt.ClearedDate = DateOnly.FromDateTime(DateTime.Now);

            await Task.Run(() => SaveAll(debts, AppDebtsFilePath)); // Simulate async file write
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error clearing debt: {ex.Message}");
            return false;
        }
    }
}
