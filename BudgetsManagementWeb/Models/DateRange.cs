using System;

namespace BudgetsManagementWeb.Models
{
    public class DateRange
    {
        private readonly DateTime _dateFrom;
        private readonly DateTime _dateTo;

        public DateRange( DateTime dateFrom , DateTime dateTo )
        {
            
            this._dateFrom = dateFrom;
            this._dateTo = dateTo;
        }

        public int Days => ( _dateTo - _dateFrom ).Days + 1;

        public DateTime DateFrom => _dateFrom;

        public DateTime DateTo => _dateTo;


    }
}