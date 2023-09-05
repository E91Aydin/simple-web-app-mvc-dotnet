using Microsoft.AspNetCore.Mvc;
using SimpleWebAppMVC.Models;
using System.Diagnostics;
using System.Reflection;

namespace SimpleWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET /Home/About
        public IActionResult About()
        {
            var location    = Assembly.GetExecutingAssembly().Location;
            var versionInfo = FileVersionInfo.GetVersionInfo(location);

            var model = new About
            {
                AppName   = versionInfo.ProductName,
                Copyright = versionInfo.LegalCopyright,
                Url       = "https://www.dynatrace.com/",
                Version   = ("Version " + versionInfo.ProductVersion)
            };

            return View(model);
        }

        // GET /Home/Error
        public IActionResult Error()
        {
            var model = new ErrorViewModel
            {
                RequestId = (Activity.Current?.Id ?? HttpContext.TraceIdentifier)
            };

            return View(model);
        }

        // GET [ /, /Home/, /Home/Index ]
        public IActionResult Index()
        {
            ViewData["message_short"] = "This test app for monitoring Dynatrace";
            ViewData["message_long"]  = " Слава Україні ':ukraine:' ':heart:'";

            return View();
        }
    }
}
