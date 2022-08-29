using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Test.Controllers
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
            DateTime date = DateTime.Now;
            ViewBag.Date = date;

            Consumption data = new Consumption("2022/01/01 12:30", "便當", 85);
            return View(data);
        }
        public IActionResult Record(string time, string item, int price)
        {
            Consumption data = new Consumption(time, item, price);
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
