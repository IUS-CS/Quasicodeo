using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TooBroke.Models;

namespace TooBroke.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Informational home page telling about the calculators
            return View();
        }

        public IActionResult Splash()
        {
            // This page will be the list of calculators for the user
            ViewData["Message"] = "User internal page of calculators.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
