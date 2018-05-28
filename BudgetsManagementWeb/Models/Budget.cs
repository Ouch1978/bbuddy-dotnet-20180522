using System;

namespace BudgetsManagementWeb.Models
{
    public class Budget
    {
        private string _yearMonth;

        private int _year;

        private int _month;

        private int _daysInMonth;

        private DateTime _dateTime;

        private DateTime _firstDayOfMonth;

        private DateTime _lastDayOfMonth;

        private decimal _budgetPerDay;

        public string YearMonth
        {
            get => _yearMonth;

            set
            {
                _yearMonth = value;

                _dateTime = DateTime.ParseExact( this.YearMonth , Constants.YearMonthFormat , null );

                _year = _dateTime.Year;
                _month = _dateTime.Month;

                _daysInMonth = DateTime.DaysInMonth( _year , _month );

                _firstDayOfMonth = new DateTime( _year , _month , 1 );
                _lastDayOfMonth = new DateTime( _year , _month , _daysInMonth );
            }
        }

        public decimal Amount { get; set; }

        internal decimal CalculateAvailableBudget( DateRange dateRange )
        {
            int overlappedDays = CalculateOverlappedDays( dateRange );

            if( overlappedDays == _daysInMonth )
            {
                return this.Amount;
            }

            _budgetPerDay = Amount / _daysInMonth;

            return _budgetPerDay * overlappedDays;
        }

        private int CalculateOverlappedDays( DateRange dateRange )
        {
            if( dateRange.DateFrom <= _firstDayOfMonth && dateRange.DateTo >= _lastDayOfMonth )
            {
                return _daysInMonth;
            }

            var firstDay = dateRange.DateFrom <= _firstDayOfMonth ? _firstDayOfMonth : dateRange.DateFrom;

            var lastDay = dateRange.DateTo >= _lastDayOfMonth ? _lastDayOfMonth : dateRange.DateTo;

            return ( lastDay - firstDay ).Days + 1;
        }
    }
}