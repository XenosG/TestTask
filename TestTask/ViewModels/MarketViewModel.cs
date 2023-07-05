using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.ViewModels
{
    public class MarketViewModel : ViewModelBase
    {
        private readonly Market _market;

        public string Name => _market.Name;

        public string Price => _market.Price.ToString("0.000000");

        public MarketViewModel(Market market)
        {
            _market = market;
        }
    }
}
