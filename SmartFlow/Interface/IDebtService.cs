using SmartFlow.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartFlow.Services.Interface
{
    public interface IDebtService
    {
        /// Retrieves all debts.
        List<Debt> GetAllDebts();

        /// Adds a new debt to the collection.
        Task<bool> AddDebtAsync(Debt debt);

        /// Marks a debt as cleared and updates its status.
        Task<bool> ClearDebtAsync(int id);
        Task<bool> UpdateDebt(Debt updatedDebt);

    }
}
