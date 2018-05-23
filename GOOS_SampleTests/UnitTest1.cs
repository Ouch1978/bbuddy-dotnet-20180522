using System;
using System.Globalization;
using GOOS_Sample.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GOOS_SampleTests
{
    [TestClass]
    public class CurrentTimeUnitTest
    {
        [TestMethod]
        public void TestCurrentTime()
        {
            //Arrange
            CurrentTimeController controller = new CurrentTimeController();

            DateTime temp;

            //Action
            string actual = controller.GetNowString();

            //Assert
            Assert.IsTrue( DateTime.TryParseExact( actual , "yyyy/MM/dd HH:mm:ss.fff" , null , DateTimeStyles.None , out temp ) );
        }
    }
}
