using AngularJSDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WSTest()
        {
            WebScrapeDemoService wsdService = new WebScrapeDemoService();
            //view needs an object to pass into it
            return View(new WSResult { Headlines = wsdService.TestScrape() });

        }
    }

    public class WSResult
    {
        public string Headlines { get; set; }
    }

}