using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeFeature()]
        [Scope( Tag = "web" )]
        public static void SetBrowser()
        {

            SeleniumWebDriver.Bootstrap( SeleniumWebDriver.Browser.Chrome );
        }

        [BeforeScenario()]
        public void BeforeScenarioCleanTable()
        {
            CleanTableByTags();
        }

        [AfterFeature()]
        public static void AfterFeatureCleanTable()
        {
            CleanTableByTags();
        }

        private static void CleanTableByTags()
        {

            var tags = ScenarioContext.Current.ScenarioInfo.Tags

                .Where( x => x.StartsWith( "Clean" ) )

                .Select( x => x.Replace( "Clean" , "" ) );

            if( !tags.Any() )
            {
                return;
            }

            //using( var dbcontext = new NorthwindEntities() )
            //{

            //    foreach( var tag in tags )
            //    {
            //        dbcontext.Database.ExecuteSqlCommand( $"TRUNCATE TABLE [{tag}]" );
            //    }

            //    dbcontext.SaveChangesAsync();

            //}

        }

    }

}

