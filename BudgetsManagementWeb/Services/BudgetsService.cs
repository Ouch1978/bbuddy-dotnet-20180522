using System;
using System.Collections.Generic;
using BudgetsManagementWeb.Models;
using System.Linq;

namespace BudgetsManagementWeb.Services
{
    public class BudgetsService
    {
        private BudgetsRepository _budgetsRepository;

        public const string YearMonthFormat = "yyyy-MM";

        public BudgetsService( BudgetsRepository budgetsRepository )
        {
            this._budgetsRepository = budgetsRepository;
        }

        public decimal CalculateAvailableBudget( DateTime dateFrom , DateTime dateTo )
        {
            List<Budget> budgets = _budgetsRepository.Budgets.Where
            ( b =>
                ( string.CompareOrdinal( dateTo.ToString( YearMonthFormat ) , b.YearMonth ) >= 0 )
            &&
                ( string.CompareOrdinal( b.YearMonth , dateFrom.ToString( YearMonthFormat ) ) >= 0 )
            ).ToList();

            if ( budgets.Count == 1 )
            {
                Budget budget = budgets.First();

                DateTime yearMonth = DateTime.ParseExact( budget.YearMonth , YearMonthFormat , null );

                var days = ( dateTo - dateFrom ).Days + 1;

                var daysInMonth = DateTime.DaysInMonth( yearMonth.Year , yearMonth.Month );

                if ( days == daysInMonth )
                {
                    return budget.Amount;
                }

                var budgetPerDay = budget.Amount / daysInMonth;

                return budgetPerDay * days;
            }

            return 0;
        }
    }
}