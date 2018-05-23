using System;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests
{
    [Binding]
    public class BudgetManagementSteps : FluentTest
    {
        private string _baseUrl = "http://localhost:58527";

        [When( @"Add a budget with YearMonth ""(.*)"" and Amount (.*)" )]
        public void WhenAddABudgetWithYearMonthAndAmount( string p0 , int p1 )
        {
            I.Open( $"{_baseUrl}/Budgets/Add" );

            I.Enter( "2018-05" ).In( "#YearMonth" );

            I.Enter( 500 ).In( "#Amount" );

            I.Click( "input[type=\"submit\"]" );
        }

        [Then( @"the following budget will be added" )]
        public void ThenTheFollowingBudgetWillBeAdded( Table table )
        {
            I.Expect.Url( $"{_baseUrl}/Budgets/Index" );

            for( int i = 0 ; i < table.RowCount ; i++ )
            {
                I.Expect.Text( table.Rows[ i ][ "YearMonth" ] );
                I.Expect.Text( table.Rows[ i ][ "Amount" ] );
            }
        }
    }
}
