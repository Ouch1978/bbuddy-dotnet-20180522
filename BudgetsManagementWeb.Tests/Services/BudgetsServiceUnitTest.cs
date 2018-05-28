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
        private static readonly BudgetsRepository _budgetsRepository = Substitute.For<BudgetsRepository>();

        private static BudgetsService _budgetService;

        private DateRange _dateRange;


        [ClassInitialize()]
        public static void ClassInit( TestContext context )
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

            //Action & Assertion
            ActionAndAssert( desiredBudget: 310 );
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

            //Action & Assertion
            ActionAndAssert( desiredBudget: 10 );
        }

        [TestMethod]
        public void TestBudgetsForTwoDaysCrossMonths()
        {
            //Arrange
            BuildTestData
            (
                budgets: new List<Budget> { new Budget { YearMonth = "2018-06" , Amount = 300 } } ,
                dateFrom: new DateTime( 2018 , 05 , 31 ) ,
                dateTo: new DateTime( 2018 , 06 , 01 )
            );

            //Action & Assertion
            ActionAndAssert( desiredBudget: 10 );
        }

        [TestMethod]
        public void TestBudgetsForPeriodCrossMonths()
        {
            //Arrange
            BuildTestData
            (
                budgets: new List<Budget>
                {
                    new Budget { YearMonth = "2018-05" , Amount = 310 },
                    new Budget { YearMonth = "2018-06" , Amount = 300 },
                } ,
                dateFrom: new DateTime( 2018 , 05 , 31 ) ,
                dateTo: new DateTime( 2018 , 06 , 01 )
            );

            //Action & Assertion
            ActionAndAssert( desiredBudget: 20 );
        }

        [TestMethod]
        public void TestBudgetsForPeriodCross3Months()
        {
            //Arrange
            BuildTestData
            (
                budgets: new List<Budget>
                {
                    new Budget { YearMonth = "2018-05" , Amount = 310 },
                    new Budget { YearMonth = "2018-07" , Amount = 310 },
                } ,
                dateFrom: new DateTime( 2018 , 05 , 31 ) ,
                dateTo: new DateTime( 2018 , 07 , 31 )
            );

            //Action & Assertion
            ActionAndAssert( desiredBudget: 320 );
        }

        [TestMethod]
        public void TestBudgetsForDateFromAfterDateTo()
        {
            //Arrange
            BuildTestData
            (
                budgets: new List<Budget>
                {
                    new Budget { YearMonth = "2018-05" , Amount = 310 },
                    new Budget { YearMonth = "2018-07" , Amount = 310 },
                } ,
                dateFrom: new DateTime( 2018 , 07 , 01 ) ,
                dateTo: new DateTime( 2018 , 04 , 30 )
            );

            //Action & Assertion
            ActionAndAssert( desiredBudget: 0 );
        }


        private void BuildTestData( List<Budget> budgets , DateTime dateFrom , DateTime dateTo )
        {
            _budgetsRepository.Budgets.Returns( budgets );

            _dateRange = new DateRange( dateFrom , dateTo );
        }

        private void ActionAndAssert( decimal desiredBudget )
        {
            decimal actual = _budgetService.CalculateAvailableBudget( _dateRange );

            Assert.AreEqual( desiredBudget , actual );
        }
    }
}
