using System.Collections.Generic;

namespace BudgetsManagementWeb.Models
{
    public interface IBudgetsRepository
    {
        IEnumerable<Budget> Budgets { get; }
    }
}