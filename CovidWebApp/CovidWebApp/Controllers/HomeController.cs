using CovidWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CovidWebApp.Data;
using System.Linq;

namespace CovidWebApp.Controllers
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
            return View();
        }

        public async Task<ViewResult> Result()
        {
            CountryBase countryBase = new CountryBase();
            await countryBase.readData("https://api.covid19api.com/summary");


            SingleCountryModel[] singleCountryModels = countryBase.GetCountryModel().Countries;
            var orderedCountryList = from country in singleCountryModels
                                     orderby country.TotalConfirmed descending
                                     select country;

            singleCountryModels = orderedCountryList.ToArray();
            SingleCountryModel[] countryArr = new SingleCountryModel[20];

            for (int i = 0; i < 20; i++)
            {
                countryArr[i] = singleCountryModels[i];
            }
            ViewData["Message"] = countryArr;

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