using System.Collections.Generic;

namespace GOOS_Sample.Models
{
    public interface IBudgetsService
    {
        List<Budget> ListAllBudgets();
        bool AddBudget( Budget budget );
    }
}