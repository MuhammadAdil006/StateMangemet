using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;
using System.Diagnostics;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(!HttpContext.Request.Cookies.ContainsKey("firstTimeAccessed"))
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);//setting session expire to 1 day
                HttpContext.Response.Cookies.Append("firstTimeAccessed", DateTime.Now.ToString(),options);
            }
           
            return View();
        }

        public IActionResult Privacy()
        {
            String date = HttpContext.Request.Cookies["firstTimeAccessed"];

            return View("Privacy",date);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}