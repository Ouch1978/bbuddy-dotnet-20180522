using System;
using System.Collections.Generic;
using BudgetsManagementWeb.Models;
using BudgetsManagementWeb.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BudgetsManagementWeb.Tests.Services
{
    [TestClass]
    public class BudgetsServiceUnitTest
    {
        readonly BudgetsRepository _budgetsRepository = Substitute.For<BudgetsRepository>();

        readonly BudgetsService _budgetService;

        private DateRange _dateRange;

        public BudgetsServiceUnitTest()
        {
            _budgetService = new BudgetsService( _budgetsRepository );
        }

        [TestMethod]
        public void TestBudgetsCoveredFullMonth()
        {
            //Arrange
            BuildTestData
            (
                budgets: new List<Budget> { new Budget { YearMonth = "2018-05" , Amount = 310 } } ,
                dateFrom: new DateTime( 2018 , 05 , 01 ) ,
                dateTo: new DateTime( 2018 , 05 , 31 )
            );

            decimal expected = 310;

            //Action
            decimal actual = _budgetService.CalculateAvailableBudget( _dateRange );

            //Assertion
            Assert.AreEqual( expected , actual );
        }


        [TestMethod]
        public void TestBudgetsForOneDayWithinABudget()
        {
            //Arrange
            BuildTestData
            (
                budgets: new List<Budget> { new Budget { YearMonth = "2018-05" , Amount = 310 } } ,
                dateFrom: new DateTime( 2018 , 05 , 01 ) ,
                dateTo: new DateTime( 2018 , 05 , 01 )
            );

            decimal expected = 10;

            //Action
            decimal actual = _budgetService.CalculateAvailableBudget( _dateRange );

            //Assertion
            Assert.AreEqual( expected , actual );
        }

        [TestMethod]
        public void TestBudgetsForOneDayWithoutABudget()
        {

        }

        private void BuildTestData( List<Budget> budgets , DateTime dateFrom , DateTime dateTo )
        {
            _budgetsRepository.Budgets.Returns( budgets );

            _dateRange = new DateRange( dateFrom , dateTo );
        }
    }
}
