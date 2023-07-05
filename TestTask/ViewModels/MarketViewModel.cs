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

        public decimal Price => _market.Price;

        public MarketViewModel(Market market)
        {
            _market = market;
        }
    }
}
