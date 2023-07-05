using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.Models;

namespace TestTask.ViewModels
{
    public class CurrencyDetailsViewModel : ViewModelBase
    {
        public ICommand ReturnToListCommand { get; }

        private readonly Currency _currency;

        public string Name => _currency.Name;

        public string Code => _currency.Code;

        public decimal Price => _currency.Price;

        public string Change => _currency.PriceChange.ToString() + "%";

        public decimal Volume => _currency.Volume;

        private readonly ObservableCollection<MarketViewModel> _markets;

        public IEnumerable<MarketViewModel> Markets => _markets;

        public CurrencyDetailsViewModel(Currency currency)
        {
            _markets = new ObservableCollection<MarketViewModel>();

            _currency = currency;
        }

    }
}
