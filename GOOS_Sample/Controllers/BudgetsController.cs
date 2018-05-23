using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;

namespace GOOS_Sample.Controllers
{
    public class BudgetsController : Controller
    {
        private IBudgetService _budgetService;

        public BudgetsController()
        {
            if( _budgetService == null )
            {
                _budgetService = new BudgetService();
            }
        }

        public BudgetsController( IBudgetService budgetService )
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
        public ActionResult Add( FormCollection collection )
        {
            try
            {

                if( ModelState.IsValid == true )
                {
                    Budget budget = new Budget();

                    TryUpdateModel<Budget>(budget, collection);

                    _budgetService.AddBudget(budget);
                }

                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }


    }
}
