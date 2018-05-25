using System;
using System.Collections.Generic;
using BudgetsManagementWeb.Models;
using System.Linq;

namespace BudgetsManagementWeb.Services
{
    public class BudgetsService
    {
        private IBudgetsRepository _budgetsRepository;

        public const string YearMonthFormat = "yyyy-MM";

        public BudgetsService( IBudgetsRepository budgetsRepository )
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

            if(budgets.Count == 1 )
            {
                return budgets.First().Amount;
            }

            return 0;
        }
    }
}