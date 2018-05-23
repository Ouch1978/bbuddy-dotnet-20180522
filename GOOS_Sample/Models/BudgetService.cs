using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IBudgetsRepository _budgetsRepository;

        public BudgetService()
        {
            if( _budgetsRepository == null )
            {
                _budgetsRepository = new BudgetsRepository();
            }
        }

        public BudgetService( IBudgetsRepository budgetsRepository )
        {
            _budgetsRepository = budgetsRepository;
        }

        public List<Budget> ListAllBudgets()
        {
            return _budgetsRepository.Budgets.ToList();
        }

        private Budget FindBudgetByYearMonth( string yearMonth )
        {
            return _budgetsRepository.Budgets.FirstOrDefault( b => b.YearMonth == yearMonth );
        }

        public bool AddBudget( Budget budget )
        {
            Budget existingBudget = FindBudgetByYearMonth( budget.YearMonth );

            if( existingBudget == null )
            {
                _budgetsRepository.Budgets.Add(budget);
            }
            else
            {
                existingBudget.Amount = budget.Amount;
            }

            return _budgetsRepository.SaveChanges() > 0;
        }


    }
}