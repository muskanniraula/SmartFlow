using SmartFlow.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartFlow.Services.Interface
{
    public interface IDebtService
    {
        /// <summary>
        /// Retrieves all debts.
        /// </summary>
        /// <returns>A list of all debts</returns>
        List<Debt> GetAllDebts();

        /// <summary>
        /// Adds a new debt to the collection.
        /// </summary>
        /// <param name="debt">The debt to add</param>
        /// <returns>True if the debt was added successfully, otherwise false</returns>
        Task<bool> AddDebtAsync(Debt debt);

        /// <summary>
        /// Marks a debt as cleared and updates its status.
        /// </summary>
        /// <param name="debtId">The ID of the debt to clear</param>
        /// <returns>True if the debt was cleared successfully, otherwise false</returns>
        Task<bool> ClearDebtAsync(int Id);
    }
}
