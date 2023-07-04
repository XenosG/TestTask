using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Currency
    {
        public string Name { get; }

        public string Code { get; }

        public decimal Price { get; }

        public float PriceChange { get; }

        public decimal Volume { get; }

        public List<Market> Markets { get; }

        public Currency(string name, string code, decimal price, float priceChange, decimal volume, List<Market> markets)
        {
            Name = name;
            Code = code;
            Price = price;
            PriceChange = priceChange;
            Volume = volume;
            Markets = markets;
        }

    }
}
