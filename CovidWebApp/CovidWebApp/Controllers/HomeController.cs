using CovidWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CovidWebApp.Data;
using System.Linq;

namespace CovidWebApp.Controllers
{
    // wygenerowany na starcie kontroler; strona startowa, polityka prywatnosci, strona bledu
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}