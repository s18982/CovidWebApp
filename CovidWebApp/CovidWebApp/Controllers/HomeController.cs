﻿using CovidWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CovidWebApp.Data;

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
            CountryBase countryBase= new CountryBase();
            await countryBase.readData("https://api.covid19api.com/summary");

            try{
                ViewData["Message"] = countryBase.GetCountryModel(); 
            }catch(Exception ex)
            {
                return View(NoContent);  
            }
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