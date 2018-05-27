﻿using System;
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
        [TestMethod]
        public void TestBudgetsCoveredFullMonth()
        {
            //Arrange
            BudgetsRepository budgetsRepository = Substitute.For<BudgetsRepository>();

            BudgetsService budgetService = new BudgetsService( budgetsRepository );

            budgetsRepository.Budgets.Returns( new List<Budget> { new Budget { YearMonth = "2018-05" , Amount = 310 } } );

            decimal expected = 310;

            DateTime dateFrom = new DateTime( 2018 , 05 , 01 );
            DateTime dateTo = new DateTime( 2018 , 05 , 31 );

            //Action
            decimal actual = budgetService.CalculateAvailableBudget( dateFrom , dateTo );

            //Assertion
            Assert.AreEqual( expected , actual );
        }

        [TestMethod]
        public void TestBudgetsForOneDayWithinABudget()
        {
            //Arrange
            BudgetsRepository budgetsRepository = Substitute.For<BudgetsRepository>();

            BudgetsService budgetService = new BudgetsService( budgetsRepository );

            budgetsRepository.Budgets.Returns( new List<Budget> { new Budget { YearMonth = "2018-05" , Amount = 310 } } );

            DateTime dateFrom = new DateTime( 2018 , 05 , 01 );
            DateTime dateTo = new DateTime( 2018 , 05 , 01 );

            decimal expected = 10;

            //Action
            decimal actual = budgetService.CalculateAvailableBudget( dateFrom , dateTo );

            //Assertion
            Assert.AreEqual( expected , actual );
        }

        [TestMethod]
        public void TestBudgetsForOneDayWithoutABudget()
        {

        }
    }
}
