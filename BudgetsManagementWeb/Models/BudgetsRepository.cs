using System.Collections.Generic;

namespace BudgetsManagementWeb.Models
{
    public class BudgetsRepository : IBudgetsRepository
    {
        public IEnumerable<Budget> Budgets { get; internal set; }
    }
}