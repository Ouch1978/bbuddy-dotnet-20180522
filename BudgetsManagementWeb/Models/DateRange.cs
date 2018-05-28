using System;

namespace BudgetsManagementWeb.Models
{
    public class DateRange
    {
        public DateTime DateFrom { get; }

        public DateTime DateTo { get; }

        public DateRange( DateTime dateFrom , DateTime dateTo )
        {
            
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

        public int Days => ( DateTo - DateFrom ).Days + 1;

    }
}