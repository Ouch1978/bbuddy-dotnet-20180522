using System.Collections.Generic;

namespace BudgetsManagementWeb.Models
{
    public class BudgetsRepository : IBudgetsRepository
    {
        public virtual IEnumerable<Budget> Budgets { get; internal set; }
    }
}