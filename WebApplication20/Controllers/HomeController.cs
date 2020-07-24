using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication20.Controllers
{
    public class HomeController : Controller
    {
        //private TelemetryClient telemetry = TelemetryClient();
        public ActionResult Index()
        {
            //telemetry.GetMetric("testMetric").TrackValue(42);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}