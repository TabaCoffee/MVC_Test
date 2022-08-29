using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;

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
            //SQLiteConnection connection = new SQLiteConnection("data source = TestDB.sql");
            //connection.Open();
            //SQLiteCommand cmd = new SQLiteCommand("create table TestTable (TIME text null, ITEM text null, PRICE int null)", connection);
            //cmd.ExecuteNonQuery();
            //cmd.Dispose();
            //connection.Close();
            //connection.Dispose();
            return View();
        }

        public IActionResult Record(string time, string item, int price)
        {
            Consumption data = new Consumption("2022/08/08 12:30", "飯糰", 25);
            return View(data);
        }

        public IActionResult New(string time, string item, int price)
        {
            SQLiteConnection connection = new SQLiteConnection("data source = TestDB.sql");
            connection.Open();
            string str = "insert into TestTable values ('" + time + "', '" + item + "', " + price.ToString() + ")";
            SQLiteCommand cmd = new SQLiteCommand(str, connection);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            connection.Close();
            connection.Dispose();

            return RedirectToAction("Index","Home");
        }

        public IActionResult Display()
        {
            SQLiteConnection connection = new SQLiteConnection("data source = TestDB.sql");
            connection.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from TestTable", connection);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Consumption> list = new List<Consumption>();
            while (reader.Read())
            {
                list.Add(new Consumption(reader["TIME"].ToString(), reader["ITEM"].ToString(),(int)reader["PRICE"]));
            }
            ViewBag.List = list;

            cmd.Dispose();
            connection.Close();
            connection.Dispose();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
