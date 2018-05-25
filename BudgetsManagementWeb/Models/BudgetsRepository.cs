using System.Collections.Generic;

namespace BudgetsManagementWeb.Models
{
    public class BudgetsRepository 
    {
        public virtual IEnumerable<Budget> Budgets { get; internal set; }
    }
}