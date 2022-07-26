using CovidWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CovidWebApp.Data;
using System.Linq;

namespace CovidWebApp.Controllers
{
    public class CovidController : Controller
    {
        public async Task<ViewResult> Index()
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
    }
}
