using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.Commands;
using TestTask.Models;
using TestTask.Stores;

namespace TestTask.ViewModels
{
    public class CurrencyViewModel : ViewModelBase
    {
        public ICommand OpenDetailsCommand { get; }

        private readonly Currency _currency;

        public string Name => _currency.Name;

        public string Code => _currency.Code;

        public string Price => _currency.Price.ToString("0.000");

        public string Change => (_currency.PriceChange < 0 ? "" : "+") + _currency.PriceChange.ToString("0.000") + "%";

        public string Volume => _currency.Volume.ToString("0.000");

        public CurrencyViewModel(NavigationStore navigationStore, Currency currency)
        {
            _currency = currency;

            OpenDetailsCommand = new OpenDetailsCommand(navigationStore, _currency);
        }

    }
}
