using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;

namespace GOOS_Sample.Controllers
{
    public class BudgetsController : Controller
    {
        private IBudgetsService _budgetService;

        public BudgetsController()
        {
            if( _budgetService == null )
            {
                _budgetService = new BudgetsService();
            }
        }

        public BudgetsController( IBudgetsService budgetService )
        {
            _budgetService = budgetService;
        }

        // GET: Budgets
        public ActionResult Index()
        {
            return View( _budgetService.ListAllBudgets() );
        }

        // GET: Budgets/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Budgets/Add
        [HttpPost]
        public ActionResult Add( Budget budget )
        {
            try
            {

                if( ModelState.IsValid == true )
                {

                    _budgetService.AddBudget( budget );
                }

                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public int Calculate( DateRange dateRange )
        {
            int sum = 0;

            if( ModelState.IsValid == true )
            {
                DateTime startdate = dateRange.Bebin;

                while( startdate <= dateRange.End )
                {
                    var budget = _budgetService.ListAllBudgets().FirstOrDefault( b => b.YearMonth == startdate.ToString( "yyyy-MM" ) );

                    if( budget != null )
                    {
                        DateTime month = DateTime.ParseExact( budget.YearMonth , "yyyy-MM" , CultureInfo.InvariantCulture );

                        int average = ( int ) budget.Amount / DateTime.DaysInMonth( month.Year , month.Month );

                        var sumOfThisMonth = average * ( DateTime.DaysInMonth( month.Year , month.Month ) - startdate.Day + 1 );

                        sum += sumOfThisMonth;

                        if( startdate.Year == dateRange.End.Year && startdate.Month == dateRange.End.Month )
                        {
                            sum -= average * ( DateTime.DaysInMonth( month.Year , month.Month ) - dateRange.End.Day );
                        }

                    }

                    if (startdate.Month == 12)
                    {
                        startdate = new DateTime( startdate.Year + 1 , 1 , 1 );
                    }
                    else
                    {
                        startdate = new DateTime( startdate.Year , startdate.Month + 1 , 1 );
                    }
                }

            }

            return sum;

        }

    }
}
