using System;
using System.Collections.Generic;
using BudgetsManagementWeb.Models;
using System.Linq;

namespace BudgetsManagementWeb.Services
{
    public class BudgetsService
    {
        private BudgetsRepository _budgetsRepository;

        public BudgetsService( BudgetsRepository budgetsRepository )
        {
            this._budgetsRepository = budgetsRepository;
        }

        public decimal CalculateAvailableBudget( DateRange dateRange )
        {
            List<Budget> budgets = FindBudgetsInRange( dateRange );

            return budgets.Sum( b => b.CalculateAvailableBudget( dateRange ) );
        }

        private List<Budget> FindBudgetsInRange( DateRange dateRange )
        {
            return _budgetsRepository.Budgets.Where
            ( b =>
                ( string.CompareOrdinal( dateRange.DateTo.ToString( Constants.YearMonthFormat ) , b.YearMonth ) >= 0 )
                &&
                ( string.CompareOrdinal( b.YearMonth , dateRange.DateFrom.ToString( Constants.YearMonthFormat ) ) >= 0 )
            ).ToList();
        }
    }
}