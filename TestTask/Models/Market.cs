using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Market
    {
        public string Name { get; }

        public decimal Price { get; }

        public Market(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
