using System;
using System.Web.Mvc;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GOOS_SampleTests
{
    [TestClass]
    public class BudgetsControllerUnitTest
    {
        [TestMethod]
        public void TestAddAction()
        {
            //Arrange
            string yearMonth = "2018-05";

            int amount = 500;

            IBudgetsService budgetService = Substitute.For<IBudgetsService>();

            BudgetsController controller = new BudgetsController( budgetService );

            Budget budget = new Budget {YearMonth = yearMonth, Amount = amount};

            //Action
            controller.Add( budget );

            //Assert

            budgetService.Received( 1 )
                .AddBudget( Arg.Is<Budget>( b => b.YearMonth == yearMonth && b.Amount == amount ) );
        }

        [TestMethod]
        public void TestIndexAction()
        {
        }
    }
}
