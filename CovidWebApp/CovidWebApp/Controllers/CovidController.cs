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
            ViewData["GlobalTotalConfirmed"] = countryBase.GetCountryModel().Global.TotalConfirmed;
            ViewData["GlobalNewConfirmed"] = countryBase.GetCountryModel().Global.NewConfirmed;
            return View();
        }

        public async Task<ViewResult> Country(string id)
        {
            CountryBase countryBase = new CountryBase();
            await countryBase.readData("https://api.covid19api.com/summary");

            SingleCountryModel[] singleCountryModels = countryBase.GetCountryModel().Countries;

            bool exist = false;
            
            foreach (SingleCountryModel s in singleCountryModels)
            {
                if(s.CountryCode.Equals(id))
                    exist = true;
            }

            if (exist == false)
                return null;

            SingleCountryModel countryModel = singleCountryModels
                                              .Where(x=>x.CountryCode.Equals(id)).First();

            ViewData["CountryCode"] = countryModel.CountryCode;
            ViewData["Country"] = countryModel.Country;
            ViewData["NewConfirmed"] = countryModel.NewConfirmed;
            ViewData["TotalConfirmed"] = countryModel.TotalConfirmed;
            ViewData["NewDeaths"] = countryModel.NewDeaths;
            ViewData["TotalDeaths"] = countryModel.TotalDeaths;
            ViewData["NewRecovered"] = countryModel.NewRecovered;
            ViewData["TotalRecovered"] = countryModel.TotalRecovered;

            return View();
        }
    }
}
