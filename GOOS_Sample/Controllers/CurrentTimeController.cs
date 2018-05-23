using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOOS_Sample.Controllers
{
    public class CurrentTimeController : Controller
    {
        private const string DateTimeFormat = "yyyy/MM/dd HH:mm:ss.fff";

        // GET: CurrentTime
        public string GetNowString()
        {
            return DateTime.Now.ToString( DateTimeFormat );
        }
    }
}