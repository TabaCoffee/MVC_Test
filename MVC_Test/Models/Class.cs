using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Test.Models
{
    public class Consumption
    {
        public string Time { get; set; }
        public string Item { get; set; }
        public int Price { get; set; }

        public Consumption()
        {
            Time = string.Empty;
            Item = string.Empty;
            Price = 0;
        }

        public Consumption(string _time, string _item, int _price)
        {
            Time = _time;
            Item = _item;
            Price = _price;
        }

        public override string ToString()
        {
            return $"時間:{Time}, 品項:{Item}, 價格:{Price}";
        }
    }
}
