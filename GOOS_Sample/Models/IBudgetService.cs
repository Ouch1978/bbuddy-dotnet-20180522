using System.Collections.Generic;

namespace GOOS_Sample.Models
{
    public interface IBudgetService
    {
        List<Budget> ListAllBudgets();
        bool AddBudget( Budget budget );
    }
}