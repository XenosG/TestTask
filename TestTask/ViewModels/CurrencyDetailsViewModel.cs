using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.API;
using TestTask.Commands;
using TestTask.Models;
using TestTask.Stores;

namespace TestTask.ViewModels
{
    public class CurrencyDetailsViewModel : ViewModelBase
    {
        public ICommand ReturnToExplorerCommand { get; }

        private readonly Currency _currency;

        public string Name => _currency.Name;

        public string Code => _currency.Code;

        public string Price => _currency.Price.ToString("0.000000");

        public string Change => (_currency.PriceChange < 0 ? "" : "+") + _currency.PriceChange.ToString("0.000000") + "%";

        public string Volume => _currency.Volume.ToString("0.000000");

        private readonly ObservableCollection<MarketViewModel> _markets;

        public IEnumerable<MarketViewModel> Markets => _markets;

        public CurrencyDetailsViewModel(NavigationStore navigationStore, Currency currency)
        {
            _markets = new ObservableCollection<MarketViewModel>();

            _currency = currency;

            ReturnToExplorerCommand = new ReturnToExplorerCommand(navigationStore);

            _ = GetList(navigationStore);
        }

        public async Task GetList(NavigationStore navigationStore)
        {
            List<Market> ApiList = await ApiHelper.GetMarketList(_currency.Id);

            var List = ApiList;

            foreach (var market in List)
            {
                _markets.Add(new MarketViewModel(market));
            }

        }

    }
}
